using Animals.Application.Domain.Animals.Queries.GetAnimalDetails;
using Animals.Application.Domain.Animals.Queries.GetAnimalsByName;
using Animals.Persistence.Core.Animals.DataProvider;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimalsByName
{
    internal class GetAnimalsByNameQueryHandler(IAnimalsDataProvider animalsDataProvider) : IRequestHandler<GetAnimalsByNameQuery, List<AnimalsByNameDto>>
    {
        public async Task<List<AnimalsByNameDto>> Handle(GetAnimalsByNameQuery request, CancellationToken cancellationToken)
        {
            var animals = await animalsDataProvider.GetAll();
            var filtredAnimals = animals
                .Where(a => a.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.Name)
                .Select(a => new AnimalsByNameDto(a.Id, a.Name, a.Age))
                .ToList();

            return await Task.FromResult(filtredAnimals);
        }
    }
}
