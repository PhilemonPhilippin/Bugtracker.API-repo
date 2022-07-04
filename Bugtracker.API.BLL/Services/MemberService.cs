using Bugtracker.API.BLL.CustomExceptions;
using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            MemberEntity memberEntity = _memberRepository.GetById(id);
            if (memberEntity is null)
                return null;
            else
                return memberEntity.ToDto();
        }
        public int Add(MemberDto memberDto)
        {
            bool pseudoExist = false;
            bool emailExist = false;

            if (_memberRepository.MemberPseudoExist(memberDto.Pseudo))
                pseudoExist = true;

            if (_memberRepository.MemberEmailExist(memberDto.Email))
                emailExist = true;

            if (pseudoExist && emailExist)
                throw new MemberException("Pseudo and Email already exist.");
            else if (pseudoExist)
                throw new MemberException("Pseudo already exists.");
            else if (emailExist)
                throw new MemberException("Email already exists.");


            string memberHashedPswd = Argon2.Hash(memberDto.PswdHash);
            memberDto.PswdHash = memberHashedPswd;
            return _memberRepository.Add(memberDto.ToEntity());
        }
        public bool Remove(int id)
        {
            return _memberRepository.Remove(id);
        }

        public bool Edit(int id, MemberDto memberDto)
        {
            bool pseudoExist = false;
            bool emailExist = false;

            if (_memberRepository.MemberPseudoExistWithId(memberDto.Pseudo, memberDto.IdMember))
                pseudoExist = true;

            if (_memberRepository.MemberEmailExistWithId(memberDto.Email, memberDto.IdMember))
                emailExist = true;

            if (pseudoExist && emailExist)
                throw new MemberException("Pseudo and Email already exist.");
            else if (pseudoExist)
                throw new MemberException("Pseudo already exists.");
            else if (emailExist)
                throw new MemberException("Email already exists.");

            return _memberRepository.Edit(id, memberDto.ToEntity());
           
        }

    }
}
