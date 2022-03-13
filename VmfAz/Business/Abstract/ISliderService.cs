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
        IDataResult<List<Slider>> GetAll();
        IDataResult<Slider> GetById(int id);
        IResult Delete(int id);
        IResult Update(int id,SliderPostDto sliderPostDto);
        IResult Add(SliderPostDto sliderPostDto);

    }
}
