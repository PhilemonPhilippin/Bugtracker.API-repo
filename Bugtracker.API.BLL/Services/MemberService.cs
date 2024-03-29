﻿using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.BLL.Tools;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using Isopoh.Cryptography.Argon2;
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
        public string TryToLogin(MemberLoginDto loginDto)
        {
            MemberEntity entity = GetByPseudo(loginDto.Pseudo);
            if (entity.Disabled == true)
                throw new MemberException("Member has been disabled.");

            bool isPasswordCorrect = Argon2.Verify(entity.PswdHash, loginDto.Password);
            if (!isPasswordCorrect)
                throw new MemberException("Password incorrect.");
            else
            {
                TokenData tokenData = new TokenData()
                {
                    IdMember = entity.IdMember,
                    Email = entity.Email
                };
                string token = _jwtManager.GenerateToken(tokenData);
                return token;
            }
        }
        public TokenData GetTokenData(string token)
        {
            return _jwtManager.GetDataFromToken(token);
        }
        public int Register(MemberPostDto postDto)
        {
            IfExistThrowException(postDto);

            string hashedPswd = Argon2.Hash(postDto.Password);
            postDto.Password = hashedPswd;
            return _memberRepository.Register(postDto.ToPostEntity());
        }
        public bool ChangePswd(MemberPostPswdDto postPswdDto)
        {
            MemberEntity entity = _memberRepository.GetById(postPswdDto.IdMember);
            bool isPasswordCorrect = Argon2.Verify(entity.PswdHash, postPswdDto.OldPassword);
            if (!isPasswordCorrect)
                throw new MemberException("Password incorrect.");
            else
            {
                string hashedNewPswd = Argon2.Hash(postPswdDto.NewPassword);
                return _memberRepository.ChangePswd(postPswdDto.IdMember, hashedNewPswd);
            }
        }
        public bool Remove(int id)
        {
            return _memberRepository.Remove(id);
        }
        public bool Edit(MemberNoPswdDto memberEdited)
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

            IfExistWithIdThrowException(memberDto);

            return _memberRepository.Edit(memberDto.ToEntity());
        }

        public bool EditRole(int id, int role)
        {
            return _memberRepository.EditRole(id, role);
        }
        private void IfExistWithIdThrowException(MemberDto memberDto)
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
        }

        private void IfExistThrowException(MemberPostDto postDto)
        {
            bool pseudoExist = false;
            bool emailExist = false;

            if (_memberRepository.MemberPseudoExist(postDto.Pseudo))
                pseudoExist = true;

            if (_memberRepository.MemberEmailExist(postDto.Email))
                emailExist = true;

            if (pseudoExist && emailExist)
                throw new MemberException("Pseudo and Email already exist.");

            else if (pseudoExist)
                throw new MemberException("Pseudo already exists.");

            else if (emailExist)
                throw new MemberException("Email already exists.");
        }
    }
}
