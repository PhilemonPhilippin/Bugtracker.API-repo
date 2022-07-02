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
            MemberEntity entity = _memberRepository.GetById(id);
            if (entity is null)
                return null;
            else
                return entity.ToDto();
        }
        public int Add(MemberDto member)
        {
            try
            {
                return _memberRepository.Add(member.ToEntity());
            }
            catch
            {
                throw;
            }
        }
        public bool Remove(int id)
        {
            return _memberRepository.Remove(id);
        }

        public bool Update(int id, MemberDto dto)
        {
            try
            {
                return _memberRepository.Edit(id, dto.ToEntity());
            }
            catch
            {
                throw;
            }
        }

    }
}
