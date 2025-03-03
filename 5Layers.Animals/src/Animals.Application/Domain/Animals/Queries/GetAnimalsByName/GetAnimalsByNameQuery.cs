﻿using Animals.Application.Domain.Animals.Queries.GetAnimalDetails;
using MediatR;

namespace Animals.Application.Domain.Animals.Queries.GetAnimalsByName;

public record GetAnimalsByNameQuery(string Name) : IRequest<List<AnimalsByNameDto>>;