using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
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
        public MemberDto GetByLogin(string login)
        {
            MemberDto member = _memberRepository.GetByLogin(login).ToDto();
            return member;
        }
        public MemberDto Insert(MemberDto member)
        {
            int idMember = _memberRepository.Insert(member.ToEntity());
            member.IdMember = idMember;
            return member;
        }

        public bool Delete(int id)
        {
            return _memberRepository.Delete(id);
        }

    }
}
