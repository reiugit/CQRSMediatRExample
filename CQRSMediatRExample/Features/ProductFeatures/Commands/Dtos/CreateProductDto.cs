using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Dtos;

public record CreateProductDto(string Name)
{
    public Product ToProduct()
        => new() { Name = Name };
}
