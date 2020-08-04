using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasIndex(n => n.Name).IsUnique();
            builder.HasData
                (
                    new Actor[]
                    {
                        new Actor() { Id = 1,  Name = "Арнольд Шварценеггер"   },
                        new Actor() { Id = 2,  Name = "Линда Хэмилтон"         },
                        new Actor() { Id = 3,  Name = "Эдвард Ферлонг"         },
                        new Actor() { Id = 4,  Name = "Роберт Патрик"          },
                        new Actor() { Id = 5,  Name = "Эрл Боэн"               },
                        new Actor() { Id = 6,  Name = "Джо Мортон"             },
                        new Actor() { Id = 7,  Name = "С. Ипейта Меркерсон"    },
                        new Actor() { Id = 8,  Name = "Кастуло Герра"          },
                        new Actor() { Id = 9,  Name = "Дэнни Кукси"            },
                        new Actor() { Id = 10, Name = "Дженетт Голдстин"       },
                        new Actor() { Id = 11, Name = "Жан-Клод Ван Дамм"      },
                        new Actor() { Id = 12, Name = "Пэт Морита"             },
                        new Actor() { Id = 13, Name = "Дэнни Трехо"            },
                        new Actor() { Id = 14, Name = "Гэбриэлль Фицпатрик"    },
                        new Actor() { Id = 15, Name = "Ларри Дрэйк"            },
                        new Actor() { Id = 16, Name = "Винсент Скьявелли"      },
                        new Actor() { Id = 17, Name = "Дэвид ’Шарк’ Фралик"    },
                        new Actor() { Id = 18, Name = "Сайлас Уэйр Митчелл"    },
                        new Actor() { Id = 19, Name = "Джонатан Эвилдсен"      },
                        new Actor() { Id = 20, Name = "Джейми Прессли"         },
                        new Actor() { Id = 21, Name = "Лупита Нионго"          },
                        new Actor() { Id = 22, Name = "Джош Гэд"               },
                        new Actor() { Id = 23, Name = "Стивен Пикок"           },
                        new Actor() { Id = 24, Name = "Кэт Стюарт"             },
                        new Actor() { Id = 25, Name = "Александр Инглэнд"      },
                        new Actor() { Id = 26, Name = "Надя Таунсенд"          },
                        new Actor() { Id = 27, Name = "Феликс Уильямсон"       },
                        new Actor() { Id = 28, Name = "Маршалл Напье"          },
                        new Actor() { Id = 29, Name = "Генри Никсон"           },
                        new Actor() { Id = 30, Name = "Джейсон Чонг"           },
                        new Actor() { Id = 31, Name = "Дизель Ла Торрак"       },
                        new Actor() { Id = 32, Name = "Саския Бурмайстер"      },
                        new Actor() { Id = 33, Name = "Рахель Абдулрахман"     },
                        new Actor() { Id = 34, Name = "Лариса Некипелова"      },
                        new Actor() { Id = 35, Name = "Дарья Фролова"          },
                        new Actor() { Id = 36, Name = "Жанна Никонова"         },
                        new Actor() { Id = 37, Name = "Дмитрий Филимонов"      },
                        new Actor() { Id = 38, Name = "Евгений Вальц"          },
                        new Actor() { Id = 39, Name = "Петр Иващенко"          },
                        new Actor() { Id = 40, Name = "Диомид Виноградов"      },
                        new Actor() { Id = 41, Name = "Александр Головчанский" },
                        new Actor() { Id = 42, Name = "Ольга Шорохова"         },
                        new Actor() { Id = 43, Name = "Алексей Костричкин"     },
                        new Actor() { Id = 44, Name = "Александр Гаврилин"     },
                        new Actor() { Id = 45, Name = "Александр Хорлин"       },
                        new Actor() { Id = 46, Name = "Даниил Эльдаров"        },
                        new Actor() { Id = 47, Name = "Михаил Тихонов"         },
                        new Actor() { Id = 48, Name = "Антон Ковалев"          },
                        new Actor() { Id = 49, Name = "Сачие Алессио"          },
                        new Actor() { Id = 50, Name = "Стюарт Аллан"           },
                        new Actor() { Id = 51, Name = "Джеффри Аренд"          },
                        new Actor() { Id = 52, Name = "Джеймс Гаррет"          },
                        new Actor() { Id = 53, Name = "Адам Гиффорд"           },
                        new Actor() { Id = 54, Name = "Пейтон Лист"            },
                        new Actor() { Id = 55, Name = "Шон Маэр"               },
                        new Actor() { Id = 56, Name = "Дженнифер Моррисон"     },
                        new Actor() { Id = 57, Name = "Джерри О’Коннелл"       }
                    }
                );
        }
    }
}
