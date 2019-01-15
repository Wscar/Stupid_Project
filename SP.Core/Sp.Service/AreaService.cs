using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SP.Repository;
using SP.Models;
using Sp.Service.Dtos;

namespace Sp.Service
{
    public class AreaService : IAreaService
    {
        readonly IBaseRepository<SpArea> baseRepository;
        public AreaService(IBaseRepository<SpArea> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        public ResponseDto CreateArea(AreaDto dto)
        {
            var newArea = new SpArea
            {
                Name = dto.Name,
                CreateUserId = dto.CreateUserId,

                CreateTime = DateTime.Now
            };
          var area=  baseRepository.Insert(newArea);
            if (area.Id > 0)
            {
                return ResponseDto.Success(area);
            }
            else
            {
                return ResponseDto.Fail("创建区域失败");
            }
        }

        public async Task<ResponseDto> CreateAreaAsync(AreaDto dto)
        {
            var newArea = new SpArea
            {
                Name = dto.Name,
                CreateUserId = dto.CreateUserId,

                CreateTime = DateTime.Now
            };
            var area = await baseRepository.InsertAsync(newArea);
            if (area.Id > 0)
            {
                return ResponseDto.Success(area);
            }
            else
            {
                return ResponseDto.Fail("创建区域失败");
            }
        }

        public ResponseDto DeleteArea(int areaId)
        {
           var area= baseRepository.Get(x => x.Id == areaId);
            if (area != null)
            {
                baseRepository.Delete(area);
                //删除这个还要考虑是否删除板块，同时删除下面的帖子
            }
            else
            {

            }
            return ResponseDto.Success(null);
        }

        public async Task<ResponseDto> DeleteAreaAsync(int areaId)
        {
            var area = baseRepository.Get(x => x.Id == areaId);
            if (area != null)
            {
                await baseRepository.DeleteAsync(area);
                //删除这个还要考虑是否删除板块，同时删除下面的帖子
            }
            else
            {

            }
            return ResponseDto.Success(null);
        }

        public ResponseDto GetArea(string name)
        {
            var area = baseRepository.Get(x => x.Name == name);
            if (area != null)
            {
                return ResponseDto.Success(area);
            }
            else
            {
                return ResponseDto.Fail("没有找到这个区域");
            }
            
        }

        public async Task<ResponseDto> GetAreaAsync(string name)
        {
            var area = await baseRepository.GetAsync(x => x.Name == name);
            if (area != null)
            {
                return ResponseDto.Success(area);
            }
            else
            {
                return ResponseDto.Fail("没有找到这个区域");
            }
        }

        public ResponseDto GetAreas()
        {
             var areas= baseRepository.GetList();
            if (areas != null)
            {
                return ResponseDto.Success(areas);
            }
            else
            {
                return ResponseDto.Fail("没有获取到全部的帖子");
            }
        }

        public async Task<ResponseDto> GetAreasAsync()
        {
            var areas = await baseRepository.GetListAsync();
            if (areas != null)
            {
                return ResponseDto.Success(areas);
            }
            else
            {
                return ResponseDto.Fail("没有获取到全部的帖子");
            }
        }

        public ResponseDto UpdateArea(AreaDto dto)
        {
            var area = baseRepository.Get(x=>x.Id==dto.Id);
            if (area != null)
            {
               var result=  baseRepository.Update(area);
                if (result > 0)
                {
                    return ResponseDto.Success(null);
                }
                else
                {
                    return ResponseDto.Fail("更新失败");
                }
            }
            else
            {
                return ResponseDto.Fail("没有找到这个area");
            }
        }

        public async Task<ResponseDto> UpdateAreaAsync(AreaDto dto)
        {
            var area = await baseRepository.GetAsync(x => x.Id == dto.Id);
            if (area != null)
            {
                var result = await baseRepository.UpdateAsync(area);
                if (result > 0)
                {
                    return ResponseDto.Success(null);
                }
                else
                {
                    return ResponseDto.Fail("更新失败");
                }
            }
            else
            {
                return ResponseDto.Fail("没有找到这个area");
            }
        }
    }
}
