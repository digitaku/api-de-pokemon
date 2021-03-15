using Microsoft.EntityFrameworkCore;
using api_de_pokemon.Entities;


namespace api_de_pokemon.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Abilities> Abilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            MappingPokemon(builder);
            MappingAbilities(builder);
            MappingTypes(builder);
        }

        private void MappingPokemon(ModelBuilder builder)
        {
            builder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("tb_pokemon");
                entity.HasKey(column => column.Id);
                entity.Property(column => column.Name).IsRequired().HasMaxLength(30);
                entity.Property(column => column.Alias).IsRequired().HasMaxLength(30);
                entity.Property(column => column.Description).HasMaxLength(100); ;
                entity.Property(column => column.Color).HasMaxLength(30);
                entity.Property(column => column.Height).HasMaxLength(30);
                entity.Property(column => column.Weight).HasMaxLength(30);
                entity.Property(column => column.ImageUrl).IsRequired().HasMaxLength(250);
            });
            builder.Entity<Pokemon>().HasMany(a => a.Abilities).WithMany(p => p.Pokemons).UsingEntity(j => j.ToTable("tb_pokemon_abilities"));
            builder.Entity<Pokemon>().HasMany(t => t.Types).WithMany(p => p.Pokemons).UsingEntity(j => j.ToTable("tb_pokemon_types"));
        }
        private void MappingTypes(ModelBuilder builder)
        {
            builder.Entity<Types>(entity =>
            {
                entity.ToTable("tb_types");
                entity.HasKey(column => column.Id);
                entity.Property(column => column.Id).HasColumnName("id");
                entity.Property(column => column.Name).HasColumnName("name").IsRequired().HasMaxLength(30);
                entity.Property(column => column.Color).HasColumnName("color").HasMaxLength(20);

            });
            builder.Entity<Types>().HasMany(p => p.Pokemons).WithMany(t => t.Types).UsingEntity(j => j.ToTable("tb_pokemon_types"));
        }
        private void MappingAbilities(ModelBuilder builder)
        {
            builder.Entity<Abilities>(entity =>
            {
                entity.ToTable("tb_abilities");
                entity.HasKey(column => column.Id);
                entity.Property(column => column.Id).HasColumnName("id").ValueGeneratedOnAdd();
                entity.Property(column => column.Name).HasColumnName("name").IsRequired().HasMaxLength(30);
                entity.Property(column => column.IsHidden).HasColumnName("is_hidden").IsRequired();
                entity.Property(column => column.EffectDescription).HasColumnName("effect_decription").HasMaxLength(50);

            });
            builder.Entity<Abilities>().HasMany(p => p.Pokemons).WithMany(a => a.Abilities).UsingEntity(j => j.ToTable("tb_pokemon_abilities"));
        }
    }
}