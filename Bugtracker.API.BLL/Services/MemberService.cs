using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<MemberDto> GetAll()
        {
            return _memberRepository.GetAll().Select(member => member.ToDto());
        }
        public MemberDto GetById(int id)
        {
            return _memberRepository.GetById(id).ToDto();
        }
        //public MemberDto GetByLogin(string login)
        //{
        //    MemberDto member = _memberRepository.GetByLogin(login).ToDto();
        //    return member;
        //}
        public int Insert(MemberDto member)
        {
            try
            {
                return _memberRepository.Insert(member.ToEntity());
            }
            catch
            {
                throw;
            }
        }
        public bool Delete(int id)
        {
            return _memberRepository.Delete(id);
        }

        public bool Update(int id, MemberDto dto)
        {
            //return _memberRepository.Update(id, dto.ToEntity());
            bool isUpdated = false;
            try
            {
                isUpdated = _memberRepository.Update(id, dto.ToEntity());
            }
            catch
            {
                throw;
            }
            return isUpdated;
        }

    }
}
