namespace Animals.Application.Domain.Animals.Queries.GetAnimalsByName
{
    public record AnimalsByNameDto(
        Guid Id,
        string Name,
        int Age);
}
