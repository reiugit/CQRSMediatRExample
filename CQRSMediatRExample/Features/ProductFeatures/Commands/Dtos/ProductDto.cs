using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Dtos;

public record ProductDto(Guid Id, string Name)
{
    public static ProductDto FromProduct(Product product)
        => new(product.Id, $"{product.Name} (Dto)");
}
