using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Common.Enums;

namespace Infraestructure.Core.Context
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckSkillAsync();
            await CheckCountryAsync();
            await CheckProvinceAsync();
            await CheckJobPositionAsync();
            await CheckDniTypeAsync();
            await CheckRolAsync();
            await CheckCityAsync();
            await CheckAddressAsync();
            await CheckUserAsync();

        }

        private async Task CheckSkillAsync()
        {
            if (!_context.SkillsEntity.Any())
            {
                _context.SkillsEntity.AddRange(new List<SkillEntity>
                {
                    new SkillEntity
                    {
                        Description = ".NET",
                        IsVisible = true,
                    },
                    new SkillEntity
                    {
                        Description = "Angular",
                        IsVisible = true,
                    },
                    new SkillEntity
                    {
                        Description = "TS",
                        IsVisible = true,
                    },
                    new SkillEntity
                    {
                        Description = ".NET CORE",
                        IsVisible = true,
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountryAsync()
        {
            if (!_context.CountriesEntity.Any())
            {
                _context.CountriesEntity.AddRange(new List<CountryEntity>
                {
                    new CountryEntity
                    {
                        Id = (int)Enums.Country.Argentina,
                        Description = "Argentina"
                    },
                    new CountryEntity
                    {
                        Id = (int)Enums.Country.Colombia,
                        Description = "Colombia"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProvinceAsync()
        {
            if (!_context.ProvincesEntity.Any())
            {
                _context.ProvincesEntity.AddRange(new List<ProvinceEntity>
                {
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.BuenosAires,
                        Description = "Buenos Aires",
                        IdCountryEntity = (int)Enums.Country.Argentina,
                    },
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.Tucuman,
                        Description = "Tucuman",
                        IdCountryEntity = (int)Enums.Country.Argentina,
                    },
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.EntreRios,
                        Description = "Entre rios",
                        IdCountryEntity = (int)Enums.Country.Argentina,
                    },
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.Cordoba,
                        Description = "Cordoba",
                        IdCountryEntity = (int)Enums.Country.Argentina,
                    },
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.SantaFe,
                        Description = "Santa fe",
                        IdCountryEntity = (int)Enums.Country.Argentina,
                    },
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.Bogota,
                        Description = "Bogota",
                        IdCountryEntity = (int)Enums.Country.Colombia,
                    },
                    new ProvinceEntity
                    {
                        Id = (int)Enums.Province.Medellin,
                        Description = "Medellin",
                        IdCountryEntity = (int)Enums.Country.Colombia,
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckCityAsync()
        {
            if (!_context.CitiesEntity.Any())
            {
                _context.CitiesEntity.AddRange(new List<CityEntity>
                {
                    new CityEntity
                    {
                        Id = (int)Enums.City.Quilmes,
                        Description = "Quilmes",
                        IDProvinceEntity = (int)Enums.Province.BuenosAires
                    },
                    new CityEntity
                    {
                        Id = (int)Enums.City.Ezpeleta,
                        Description = "ciudad 2",
                        IDProvinceEntity = (int)Enums.Province.Tucuman
                    },
                    new CityEntity
                    {
                        Id = (int)Enums.City.Ciudad3,
                         Description = "ciudad 3",
                        IDProvinceEntity = (int)Enums.Province.SantaFe
                    },
                    new CityEntity
                    {
                        Id = (int)Enums.City.Ciudad4,
                        Description = "ciudad 4",
                        IDProvinceEntity = (int)Enums.Province.Cordoba
                    },
                    new CityEntity
                    {
                        Id = (int)Enums.City.Ciudad5,
                        Description = "ciudad 5",
                        IDProvinceEntity = (int)Enums.Province.EntreRios
                    },
                    new CityEntity
                    {
                        Id = (int)Enums.City.Ciudad6,
                        Description = "ciudad 6",
                        IDProvinceEntity = (int)Enums.Province.Medellin
                    },
                    new CityEntity
                    {
                        Id = (int)Enums.City.Ciudad7,
                        Description = "ciudad 7",
                        IDProvinceEntity = (int)Enums.Province.Bogota
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckAddressAsync()
        {
            if (!_context.AdressEntity.Any())
            {
                _context.AdressEntity.AddRange(new List<AdressEntity>
                {
                    new AdressEntity
                    {
                        Description = "piso 14",
                        Street = "mitre",
                        Number = 122,
                        IdCityEntity = 1
                    },
                    new AdressEntity
                    {
                        Description = "piso 1",
                        Street = "la cortada 3",
                        Number = 22,
                        IdCityEntity = 1

                    },
                    new AdressEntity
                    {
                      Description = "pasaje 2",
                      Street = "segurola y habana",
                        Number = 4310,
                        IdCityEntity = 1
                    }
                }); ;

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckJobPositionAsync()
        {
            if (!_context.JobPositionsEntity.Any())
            {
                _context.JobPositionsEntity.AddRange(new List<JobPositionEntity>
                {
                    new JobPositionEntity
                    {
                        Description = "Trainee"
                    },
                    new JobPositionEntity
                    {
                        Description = "Junior"

                    },
                    new JobPositionEntity
                    {
                        Description = "Senior"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDniTypeAsync()
        {
            if (!_context.DniTypesEntity.Any())
            {
                _context.DniTypesEntity.AddRange(new List<DniTypeEntity>
                {
                    new DniTypeEntity
                    {
                        Description =  "Dni"
                    },
                    new DniTypeEntity
                    {
                        Description =  "Cedula"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolAsync()
        {
            if (!_context.RolesEntity.Any())
            {
                _context.RolesEntity.AddRange(new List<RoleEntity>
                {
                    new RoleEntity
                    {
                        Id = (int)Enums.Role.Admin,
                        Description =  "Admin"
                    },
                    new RoleEntity
                    {   
                        Id = (int)Enums.Role.Recruiter,
                        Description =  "Recruiter"
                    },
                    new RoleEntity
                    {
                        Id = (int)Enums.Role.User,
                        Description =  "User"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }



        private async Task CheckUserAsync()
        {
            if (!_context.UsersEntity.Any())
            {
                _context.UsersEntity.AddRange(new List<UserEntity>
                {
                    new UserEntity
                    {
                        Mail = "admin@gmail.com",
                        Password = Common.Helpers.Utils.PassEncrypt("Test_678"),
                        IsActive = true,
                        IdRole = (int)Enums.Role.Admin,
                    },
                    new UserEntity
                    {
                        Mail = "recruiter@gmail.com",
                        Password = Common.Helpers.Utils.PassEncrypt("Test_678"),
                        IsActive = true,
                        IdRole = (int)Enums.Role.Recruiter,
                    },
                    new UserEntity
                    {
                        Mail = "user@gmail.com",
                        Password = Common.Helpers.Utils.PassEncrypt("Test_678"),
                        IsActive = true,
                        IdRole = (int)Enums.Role.User,
                    }
                });
                await _context.SaveChangesAsync();
            }
        }





        UserEntity user = new UserEntity()
        {
            
        };

    }
}
