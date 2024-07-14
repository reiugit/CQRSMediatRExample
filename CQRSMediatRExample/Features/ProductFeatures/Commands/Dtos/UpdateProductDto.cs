using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Dtos;

public record UpdateProductDto(string Name)
{
    public Product ToProduct()
        => new() { Name = Name };
}
