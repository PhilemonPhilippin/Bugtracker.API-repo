using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.BLL.Tools;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bugtracker.API.BLL.Tools.JwtManager;

namespace Bugtracker.API.BLL.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _memberRepository;
        private JwtManager _jwtManager;

        public MemberService(JwtManager jwtManager, IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            _jwtManager = jwtManager;
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
        private MemberEntity GetByPseudo(string pseudo)
        {
            MemberEntity entity = _memberRepository.GetByPseudo(pseudo);
            if (entity is null)
                throw new MemberException("Member pseudo not found.");
            else
                return entity;
        }
        public ConnectedMemberDto TryToLogin(MemberLoginDto loginDto)
        {
            MemberEntity entity = GetByPseudo(loginDto.Pseudo);
  
            bool isPasswordCorrect = Argon2.Verify(entity.PswdHash, loginDto.Password);
            if (!isPasswordCorrect)
                throw new MemberException("Password incorrect.");
            else
            {
                MemberDto memberDto = entity.ToDto();
                TokenData tokenData = new TokenData()
                {
                    IdMember = memberDto.IdMember,
                    Email = memberDto.Email
                };
                string token = _jwtManager.GenerateToken(tokenData);
                return memberDto.ToConnectedDto(token);
            }
        }

        // Si je veux refresh les tokens.
        //public ConnectedMemberDto RefreshToken(string token)
        //{
        //    DataToken data = _jwtManager.GetDataFromToken(token);
        //    string newToken = _jwtManager.GenerateToken(data);
        //    var memberDto = GetById(data.IdMember);
        //    ConnectedMemberDto connectedMember = memberDto.ToConnectedMember(newToken);
        //    return connectedMember;
        //}

        public int Add(MemberDto memberDto)
        {
            IfExistThrowException(memberDto);

            string memberHashedPswd = Argon2.Hash(memberDto.PswdHash);
            memberDto.PswdHash = memberHashedPswd;
            return _memberRepository.Add(memberDto.ToEntity());
        }
        public bool Remove(int id)
        {
            return _memberRepository.Remove(id);
        }

        public bool Edit(MemberEditDto memberEdited)
        {
            MemberEntity entity = _memberRepository.GetById(memberEdited.IdMember);
            MemberDto memberDto;
            if (entity is null)
                throw new MemberException("Id not found.");
            else
                memberDto = entity.ToDto();

            // Changing the member dto with edited info.
            memberDto.Pseudo = memberEdited.Pseudo;
            memberDto.Email = memberEdited.Email;
            memberDto.Firstname = memberEdited.Firstname;
            memberDto.Lastname = memberEdited.Lastname;

            IfExistThrowException(memberDto, true);

            return _memberRepository.Edit(memberDto.ToEntity());
           
        }
        private void IfExistThrowException(MemberDto memberDto, bool checkWithId = false)
        {
            bool pseudoExist = false;
            bool emailExist = false;

            if (checkWithId)
            {
                if (_memberRepository.MemberPseudoExistWithId(memberDto.Pseudo, memberDto.IdMember))
                    pseudoExist = true;

                if (_memberRepository.MemberEmailExistWithId(memberDto.Email, memberDto.IdMember))
                    emailExist = true;
            }
            else
            {
                if (_memberRepository.MemberPseudoExist(memberDto.Pseudo))
                    pseudoExist = true;

                if (_memberRepository.MemberEmailExist(memberDto.Email))
                    emailExist = true;
            }

            if (pseudoExist && emailExist)
                throw new MemberException("Pseudo and Email already exist.");

            else if (pseudoExist)
                throw new MemberException("Pseudo already exists.");

            else if (emailExist)
                throw new MemberException("Email already exists.");
        }
    }
}
