using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using MimeDetective;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        private static readonly string RootDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static AcceptableFileCategory[] AcceptableFileCategories =
        {
            new AcceptableFileCategory
            {
                ExtensionMimeType = GeneralFileTypes.Images,
                FolderName = "images",
                MaximumUploadSizeInByte = ConvertMbToByte("5")
            }
        };


        public static IResult Upload(IFormFile file)
        {
            var checkFileResult = CheckFile(file);
            if (!checkFileResult.Success)
                return new ErrorResult(checkFileResult.Message);

            string fileName = file.FileName;
            string randomGuid = Guid.NewGuid().ToString();
            string newFileName = randomGuid + "--" + (fileName.Length > 62 ? TrimFileName(fileName) : fileName);

            string folderForFileUpload = $"{checkFileResult.Data.FolderName}\\";

            string folderFullPath = $"{RootDirectory}\\{folderForFileUpload}";

            string fileFullPath = folderFullPath + newFileName;

            CheckAndCreateDirector(folderFullPath);
            CreateFile(fileFullPath, file);

            string ImagePathForDb = folderForFileUpload + newFileName;
            return new SuccessResult(ImagePathForDb.Replace("\\", "/"));

        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var checkFileResult = CheckFile(file);
            if (!checkFileResult.Success)
                return new ErrorResult(checkFileResult.Message);

            string fileName = file.FileName;
            string randomGuid = Guid.NewGuid().ToString();
            string newFileName = randomGuid + "--" + (fileName.Length > 55 ? TrimFileName(fileName) : fileName);

            string folderForFileUpload = $"{checkFileResult.Data.FolderName}\\";

            string folderFullPath = $"{RootDirectory}\\{folderForFileUpload}";

            string fileFullPath = folderFullPath + newFileName;

            Delete((RootDirectory + imagePath).Replace("/", "\\"));

            CheckAndCreateDirector(folderFullPath);
            CreateFile(fileFullPath, file);

            string ImagePathForDb = folderForFileUpload + newFileName;
            return new SuccessResult(ImagePathForDb.Replace("\\", "/"));
        }

        public static IResult Delete(string directory)
        {
            string newDirector = $"{RootDirectory}\\{directory.Replace("\\", "/")}";
            if (!File.Exists(newDirector))
            {
                File.Delete(newDirector);
                return new SuccessResult();
            }
            return new ErrorResult("File Not Found!");

        }

        private static IDataResult<ExtensionInformation> CheckFile(IFormFile file)
        {
            var extensionInRequest = Path.GetExtension(file.FileName);
            var mimeTypeInRequest = file.ContentType;

            //validate file mime Type
            var fileExtensionInformationResult = GetExtensionInformation(extensionInRequest);
            if (!fileExtensionInformationResult.Success)
                return new ErrorDataResult<ExtensionInformation>(fileExtensionInformationResult.Message);

            //validate file size
            var fileSizeLimit = fileExtensionInformationResult.Data.MaximumUploadSizeInByte;

            var currentFileSizeResult = CheckIfFileSizeIsValid(fileSizeLimit, file);
            if (!currentFileSizeResult.Success)
                return new ErrorDataResult<ExtensionInformation>(currentFileSizeResult.Message);

            //find Mime type
            var mimeTypeInHeaderResult = FindMimeTypeResult(file);
            if (!mimeTypeInHeaderResult.Success)
            {
                return new ErrorDataResult<ExtensionInformation>(mimeTypeInHeaderResult.Message);
            }

            //Validate File header mime type from acceptable mime types
            var mimeTypeInHeader = mimeTypeInHeaderResult.Data;

            var mimeTypeInHeadereIsValid = CheckIfFileMimeTypeIsValid(mimeTypeInHeader);
            if (!mimeTypeInHeadereIsValid.Success)
            {
                return new ErrorDataResult<ExtensionInformation>(mimeTypeInHeadereIsValid.Message);
            }

            var mimeTypeInFileExtension = fileExtensionInformationResult.Data.MimeType;

            var maliciousFileTypeCheck = MaliciousFileTypeDetection(mimeTypeInRequest, mimeTypeInHeader, mimeTypeInFileExtension);
            if (!maliciousFileTypeCheck.Success)
            {
                return new ErrorDataResult<ExtensionInformation>(maliciousFileTypeCheck.Message);
            }
            return new SuccessDataResult<ExtensionInformation>(fileExtensionInformationResult.Data);
        }

        private static IResult MaliciousFileTypeDetection(string mimeTypeInRequest, string mimeTypeInHeader, string mimeTypeInFileExtension)
        {
            if (mimeTypeInRequest != mimeTypeInHeader)
            {
                return new ErrorResult("Expected mime type don't match with mime type in request!");
            }
            if (mimeTypeInRequest != mimeTypeInFileExtension)
            {
                return new ErrorResult("Mime type in file header don't match with mime type in request! Yallah basqa qapiya!");
            }
            return new SuccessResult();
        }

        private static IResult CheckIfFileMimeTypeIsValid(string foundMimeTypeFromFile)
        {
            foreach (var acceptableFileCategory in AcceptableFileCategories)
            {
                foreach (var acceptableMimeType in acceptableFileCategory.ExtensionMimeType.Values)
                {
                    if (acceptableMimeType == foundMimeTypeFromFile)
                    {
                        return new SuccessResult();
                    }
                }
            }
            return new ErrorResult("Invalid Mime Type");
        }

        private static IDataResult<string> FindMimeTypeResult(IFormFile file)
        {
            var inspector = new ContentInspectorBuilder()
            {
                Definitions = MimeDetective.Definitions.Default.All()
            }.Build();

            byte[] fileContent;

            using (FileStream stream = new FileStream(Path.GetTempFileName(), FileMode.Open, FileAccess.Write, FileShare.Read, 1024, FileOptions.None))
            {
                file.CopyTo(stream);
                var tempFilePath = stream.Name;
                stream.Close();
                fileContent = ContentReader.Default.ReadFromFile(tempFilePath);
                File.Delete(tempFilePath);
            }

            var results = inspector.Inspect(fileContent);
            var resultsMimeType = results.ByMimeType();
            if (resultsMimeType.IsEmpty)
            {
                return new ErrorDataResult<string>(null, "Mime type not fount");
            }
            return new SuccessDataResult<string>(resultsMimeType[0].MimeType, "Mime type found!");

        }

        private static IResult CheckIfFileSizeIsValid(double fileSizeLimit, IFormFile file)
        {
            if (file.Length > 0 && file.Length <= fileSizeLimit)
            {
                return new SuccessResult();
            }
            return new ErrorResult($"File size is too much.\nUploaded file size:{file.Length.ToString("0.00")}.\nLimit:{fileSizeLimit}");
        }

        private static IDataResult<ExtensionInformation> GetExtensionInformation(string extension)
        {
            var newExtension = extension.ToLower();

            foreach (var fileType in AcceptableFileCategories)
            {
                foreach (var mimeType in fileType.ExtensionMimeType)
                {
                    if ($".{mimeType.Key}" == extension)
                    {
                        ExtensionInformation result = new ExtensionInformation
                        {
                            Extension = mimeType.Key,
                            MimeType = mimeType.Value,
                            FolderName = fileType.FolderName,
                            MaximumUploadSizeInByte = fileType.MaximumUploadSizeInByte,
                        };
                        return new SuccessDataResult<ExtensionInformation>(result);
                    }
                }
            }
            return new ErrorDataResult<ExtensionInformation>($"{extension} file type not acceptable!");
        }

        private static double ConvertByteToMb(string byteSize)
        {
            var newByteSize = byteSize.Replace(".", ",");
            var size = Convert.ToDouble(newByteSize);
            return size / 1048576;
        }

        private static double ConvertMbToByte(string mbSize)
        {
            var newByteSize = mbSize.Replace(".", ",");
            var size = Convert.ToDouble(newByteSize);
            return size * 1048576;
        }

        private static void CreateFile(string fileFullPath, IFormFile file)
        {
            using (FileStream stream = File.Create(fileFullPath))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
        }

        private static void CheckAndCreateDirector(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        private static string TrimFileName(string fileExtension)
        {
            return fileExtension.Substring(fileExtension.Length - 55, 55);
        }
    }
}
