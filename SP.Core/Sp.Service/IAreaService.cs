using Sp.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sp.Service
{
   public interface IAreaService
    {
        ResponseDto CreateArea(AreaDto dto);
        ResponseDto DeleteArea(int areaId);
        ResponseDto UpdateArea(AreaDto dto);
        ResponseDto GetArea(string name);
        ResponseDto GetAreas();
        Task<ResponseDto> CreateAreaAsync(AreaDto dto);
        Task<ResponseDto> DeleteAreaAsync(int areaId);
        Task<ResponseDto> UpdateAreaAsync(AreaDto dto);
        Task<ResponseDto> GetAreaAsync(string name);
        Task<ResponseDto> GetAreasAsync();
    }
}
