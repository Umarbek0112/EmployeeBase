using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.PersonalData;
using EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers;
using EmployeeBase.Service.DTOs.PersonalData.JobExperince;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.PersonalData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.PersonalData
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FamilyMemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FamilyMemberForViewDTOs> CreateAsync(FamilyMemberForCreateDTOs familyMemberForCreateDTO)
        {
            var familyMember = _mapper.Map<FamilyMember>(familyMemberForCreateDTO);
            familyMember.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.FamilyMember.CreateAsync(familyMember);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<FamilyMemberForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedFamilyMember = await _unitOfWork.FamilyMember.GetAsync(x => x.Id == id);
            if (deletedFamilyMember is null)
                throw new EmployeeBaseException(404, "FamilyMember not found");

            var deletResult = await _unitOfWork.FamilyMember.DeleteAsync(deletedFamilyMember.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<FamilyMemberForViewDTOs> GetAll(PaginationParams @params, Expression<Func<FamilyMember, bool>> expression = null)
             => _mapper.Map<IEnumerable<FamilyMemberForViewDTOs>>(
                _unitOfWork.FamilyMember.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<FamilyMemberForViewDTOs> GetAsync(Expression<Func<FamilyMember, bool>> expression)
        {
            var familyMember = await _unitOfWork.FamilyMember.GetAsync(expression, isTracking: false);
            if (familyMember is null)
                throw new EmployeeBaseException(404, "FemilyMember not found");

            return _mapper.Map<FamilyMemberForViewDTOs>(familyMember);
        }

        public async Task<FamilyMemberForViewDTOs> UpdateAsync(int id, FamilyMemberForCreateDTOs familyMemberForCreateDTO)
        {
            var updated = await _unitOfWork.FamilyMember.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "FamilyMember notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.FamilyMember.Update(_mapper.Map(familyMemberForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<FamilyMemberForViewDTOs>(updated);
        }
    }
}
