using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderService 
    {
        Task<IDataResult<List<Slider>>> GetAll();
        Task<IDataResult<Slider>> GetById(int id);
        Task<IResult> Delete(int id);
        Task<IResult> Update(int id,SliderPostDto sliderPostDto);
        IResult Add(SliderPostDto sliderPostDto);

    }
}
