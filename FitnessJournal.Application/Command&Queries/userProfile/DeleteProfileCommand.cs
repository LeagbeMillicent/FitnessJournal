﻿using AutoMapper;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Command_Queries.userProfile
{
    public class DeleteProfileCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, bool>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public DeleteProfileCommandHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetAsync(request.Id);
                if (entity == null)
                {
                    return false;
                }
                await _repository.DeleteAsync(entity);
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
