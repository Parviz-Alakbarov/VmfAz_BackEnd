using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public static class GeneralFileTypes
    {
        public static readonly Dictionary<string, string> Archives = new Dictionary<string, string>()
        {
            { "7z", "application/x-compressed" },
            { "zip", "application/x-compressed" }
        };
        public static readonly Dictionary<string, string> Documents = new Dictionary<string, string>()
        {
            { "doc", "application/msword" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "pdf", "application/pdf" },
            { "ppt", "application/mspowerpoint" },
            { "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
            { "xls", "application/excel" },
            { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }
        };

        public static readonly Dictionary<string, string> Images = new Dictionary<string, string>()
        {
            //{ "gif", "image/gif" },
            //{ "ico", "image/x-icon" },
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/png" },
        };
    }
}
