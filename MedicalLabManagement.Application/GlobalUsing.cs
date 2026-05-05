// Common
global using MediatR;
global using FluentValidation;
global using Microsoft.Extensions.DependencyInjection;
global using System.Linq.Expressions;
global using AutoMapper;

//  Domin Project
global using CategoryModel = MedicalLabManagement.Domin.Entities.Category;
global using TestModel = MedicalLabManagement.Domin.Entities.Test;
global using MedicalLabManagement.Domin.Entities;
global using MedicalLabManagement.Domin.Enums;


// Application Project
global using MedicalLabManagement.Application.Features.Category.Shared.Mapping;
global using MedicalLabManagement.Application.Features.Test.Shared.Mapping;
global using MedicalLabManagement.Application.Interfaces.Repositories;
global using MedicalLabManagement.Application.Interfaces.Specifications;
global using MedicalLabManagement.Application.Common.Exceptions;
global using MedicalLabManagement.Application.Features.Category.Shared.Dtos;
global using MedicalLabManagement.Application.Features.Category.Shared.Specifications;
global using MedicalLabManagement.Application.Interfaces.UnitOfWork;
global using MedicalLabManagement.Application.Features.Test.Shared.Dtos;
global using MedicalLabManagement.Application.Common.Specifications;