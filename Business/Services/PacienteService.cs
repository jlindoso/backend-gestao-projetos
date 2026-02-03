using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Paciente;
using Domain.Model;
using Domain.Model.Repositories;
using Domain.Ports;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;
        private readonly IAuthService _authService;
        
        public PacienteService(IPacienteRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }


        // Retorna todos os pacientes, opcionalmente filtrando por nome ou CPF
        public async Task<Response<List<PacienteDomain>>> GetAllAsync(string? filter = null)
        {
            try
            {
                var dados = await _repository.GetAllAsync(filter);

                return Response<List<PacienteDomain>>.Ok(dados);
            }
            catch (System.Exception ex)
            {

                return Response<List<PacienteDomain>>.Fail(ex.Message);
            }

        }

        public async Task<Response<PacienteDomain>> GetByIdAsync(Guid id)
        {
            try
            {
                var paciente = await _repository.GetByIdAsync(id);
                if (paciente==null)
                    throw new Exception("Paciente não encontrado!");

                return Response<PacienteDomain>.Ok(paciente);
            }
            catch (Exception ex)
            {
                return Response<PacienteDomain>.Fail(ex.Message);
            }
        }

        // Adiciona um paciente
        public async Task<Response<PacienteDomain>> AddAsync(PacienteCreateDto dto)
        {
            try
            {
                var user = new UsuarioDomain
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    CPF = dto.CPF,
                    NomeSocial = dto.NomeSocial,
                    SexoId = dto.SexoId,
                    GeneroId = dto.GeneroId
                };

                var userCreate = await _authService.AddUsuarioAsync(user, dto.Password, PerfilDomain.Paciente);
                if(!userCreate.Success)
                    throw new Exception(userCreate.Message);
                
                var paciente = new PacienteDomain
                {
                    UsuarioId = userCreate.Data.Id,
                    Created = DateTime.UtcNow,
                    Nome = dto.Nome,
                    NumeroPlanoSaude = dto.PlanoSaude
                    
                };

                await _repository.AddAsync(paciente);

                return Response<PacienteDomain>.Ok(paciente);
            }
            catch (Exception ex)
            {
                return Response<PacienteDomain>.Fail(ex.Message);
            }
        }

        // Atualiza paciente
        public async Task<Response<PacienteDomain>> UpdateAsync(PacienteDomain paciente)
        {
            try
            {
                if (paciente.Id == Guid.Empty)
                    throw new Exception("Paciente inválido.");

                var resultado = await _repository.UpdateAsync(paciente);
                if(resultado==null)
                    throw new Exception("Não foi possivel realizar atualização!");
                return Response<PacienteDomain>.Ok(resultado);
            }   
            catch (Exception ex)
            {
                return Response<PacienteDomain>.Fail(ex.Message);
            }
        }

        // Remove paciente
        public async Task<Response<bool>> DeleteAsync(Guid id)
        {
            try
            {
                var paciente = await _repository.GetByIdAsync(id);
                if (paciente==null)
                    throw new Exception("Paciente não encontrado.");

                await _repository.DeleteAsync(id);
                return Response<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail(ex.Message);
            }
        }

        Task IPacienteService.DeleteAsync(Guid id)
        {
            return DeleteAsync(id);
        }
    }
}