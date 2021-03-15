﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_de_pokemon.Context;

namespace api_de_pokemon.Migrations
{
    [DbContext(typeof(ContextDb))]
    partial class ContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("AbilitiesPokemon", b =>
                {
                    b.Property<int>("AbilitiesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AbilitiesId", "PokemonsId");

                    b.HasIndex("PokemonsId");

                    b.ToTable("tb_pokemon_abilities");
                });

            modelBuilder.Entity("PokemonTypes", b =>
                {
                    b.Property<int>("PokemonsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PokemonsId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("tb_pokemon_types");
                });

            modelBuilder.Entity("api_de_pokemon.Entities.Abilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("EffectDescription")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("effect_decription");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_hidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_abilities");
                });

            modelBuilder.Entity("api_de_pokemon.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Height")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Weight")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("tb_pokemon");
                });

            modelBuilder.Entity("api_de_pokemon.Entities.Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("color");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_types");
                });

            modelBuilder.Entity("AbilitiesPokemon", b =>
                {
                    b.HasOne("api_de_pokemon.Entities.Abilities", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_de_pokemon.Entities.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonTypes", b =>
                {
                    b.HasOne("api_de_pokemon.Entities.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_de_pokemon.Entities.Types", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}