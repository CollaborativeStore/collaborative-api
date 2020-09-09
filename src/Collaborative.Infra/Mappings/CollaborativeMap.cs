using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Infra.Mappings
{
    public class CollaborativeMap : IEntityTypeConfiguration<Collab>
    {
        public void Configure(EntityTypeBuilder<Collab> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
