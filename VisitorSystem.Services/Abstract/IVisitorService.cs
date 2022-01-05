using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.VisitorDto;
using VisitorSystem.Shared.Utilities.Results.Abstarct;

namespace VisitorSystem.Services.Abstract
{
     public interface IVisitorService
    {
        Task<IDataResult<VisitorDto>> Get(int visitorId);
        //Task<IDataResult<VisitorDto>> GetTCNoUpdateDto(long tcNo);
       
       
        Task<IDataResult<int>> GetAllCount();
        Task<IDataResult<int>> GetNotIsExit();
        Task<IDataResult<int>> GetIsExit();
        Task<IDataResult<VisitorDto>> IsExit(int  visitorId,string modifieldByName);

        Task<IDataResult<VisitorListDto>> GetAllNonDeleted();
        Task<IDataResult<VisitorListDto>> GetAllNonDeletedAndActive();

        Task<IDataResult<VisitorDto>> Add(VisitorAddDto visitorAddDto, string createdByName);

      

        Task<IDataResult<VisitorDto>> Delete(int visitorId, string modifieldByName);
        Task<IResult> HardDelete(int visitorId);


    }
}
