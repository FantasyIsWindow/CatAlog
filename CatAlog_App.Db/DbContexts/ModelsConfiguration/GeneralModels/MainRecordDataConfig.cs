﻿using CatAlog_App.ConfigurationWorker;
using CatAlog_App.Db.DbContexts.DbModels.GeneralModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.IO;

namespace CatAlog_App.Db.DbContexts.ModelsConfiguration.GeneralModels
{
    public class MainRecordDataConfig : IEntityTypeConfiguration<MainRecordData>
    {
        public void Configure(EntityTypeBuilder<MainRecordData> builder)
        {
            string Terminator = "Прошло более десяти лет с тех пор, как киборг-терминатор из 2029 года пытался уничтожить Сару Коннор - женщину, " +
                                "чей будущий сын выиграет войну человечества против машин.Теперь у Сары родился сын Джон и время, когда он поведёт " +
                                "за собой выживших людей на борьбу с машинами, неумолимо приближается. Именно в этот момент из постапокалиптического " +
                                "будущего прибывает новый терминатор - практически неуязвимый и способный принимать любое обличье. Цель нового терминатора " +
                                "уже не Сара, а уничтожение молодого Джона Коннора.Однако шансы Джона на спасение существенно повышаются, когда на помощь " +
                                "приходит перепрограммированный сопротивлением терминатор предыдущего поколения. Оба киборга вступают в смертельный бой, " +
                                "от исхода которого зависит судьба человечества. ";

            string Inferno = "Эдди Ломакс - одинокий воин, утративший веру в себя. Поиски старого друга - одинокого индейца-шамана - приводят его в разрушенный " +
                             "город с адским названием Инферно, где у Эдди много врагов. Полная луна и зов койота помогут ему обрести былую силу и осуществить " +
                             "благородную цель: защитить местных жителей от жестоких банд байкеров и контрабандистов.";

            string LittleMonsters = "Учительница начальных классов везёт группу детей за город на экскурсию, когда на местности происходит вспышка зомби-вируса. " +
                                    "Чтобы спастись и не травмировать детскую психику, женщина убеждает малышей в том, что все эти зомби, кровь, кишки - ненастоящие, " +
                                    "а всё происходящее - просто игра. Странная, но весёлая. И вот тот дядя корчится не от боли, а от радости. И не корчится, а смеётся.";

            string Batman = "В центре сюжета таинственный злодей, известный, как Хаш. Он пользуется слабостями Бэтса, чтобы разрушить его \"карьеру\" по борьбе с " +
                            "преступностью. На этом фоне личная жизнь Брюса также дает трещину, в связи с более осложнившимися отношениями с Селиной Кайл.";

            string BlackFox = "Когда наступает ночь и город погружается во тьму, которую разгоняют лишь вспышки неоновой рекламы и мягкий свет фонарей, на крыше самого " +
                              "высокого небоскреба можно заметить необычный силуэт, выделяющийся на фоне звездного неба. Кто это? Горожане яростно спорят, каждый считает " +
                              "собственную точку зрения единственно верной, поэтому спорщики пока не пришли к единому мнению. Одни утверждают, что это обыкновенный человек, " +
                              "пытающийся подобным способом добиться славы и известности. Другие, вспомнив о существовании древней городской легенды о фантоме, приходящем " +
                              "забирать гнилые души, упорно доказывают, что час расплаты за злодеяния близок и весьма скоро число населения заметно поубавится. Или это настоящий " +
                              "герой, обладающий суперсилой, готовится спасти человечество от гибели? Кто же этот незнакомец или, если судить по очаровательной стройной фигуре " +
                              "и длинным ногам, незнакомка? Девушку неоднократно пытались сфотографировать и заснять на видеокамеру, но никому не удалось разглядеть ее лица, " +
                              "скрытого под маской черной лисы.Ее час пока не пробил, но однажды все изменится. Когда она начнет действовать и покажет себя, не останется " +
                              "времени на пустые споры и ненужные беседы.";

            string Pokemon = "Новые соперники, новые друзья и множество невиданных покемонов ожидают Эша и Пикачу в новом сезоне аниме-сериала про покемонов под названием " +
                             "\"Судьбы Соперников\". Наши герои продолжают исследовать регион Юнова, и Эша ожидает сражение с серьезным соперником Элдером, чемпионом Юновы. Его друзьям также " +
                             "предстоит преодолеть свои препятствия: одна будет сражаться за право продолжить свое путешествие, другой столкнется c соперником из прошлого - и все они должны " +
                             "будут объединиться, чтобы спасти остров от сильнейшего столкновения трех таинственных и могущественных легендарных покемонов.";

            SettingsManager settings = new SettingsManager();
            string path = Path.Combine(settings.Settings.DbFolderPath, settings.Settings.GraphicDataFolderName);

            string _01 = Path.Combine(path, "Terminator 2", "title.png");
            string _02 = Path.Combine(path, "Inferno", "title.jpg");
            string _03 = Path.Combine(path, "Little Monsters", "title.jpg");
            string _04 = Path.Combine(path, "Batman - Hush", "title.jpg");
            string _05 = Path.Combine(path, "Black fox", "title.jpg");
            string _06 = Path.Combine(path, "Pokemon, Black and White - Adventures in Unova", "title.jpg");

            builder.HasOne(c => c.Category).WithMany(m => m.MainRecordsData).HasForeignKey(k => k.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(n => n.Name).WithOne(m => m.MainRecordData).HasForeignKey<NameData>(k => k.MainRecordDataId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData
                (
                    new MainRecordData[]
                    {
                        new MainRecordData()
                        {
                            Id = 1,
                            Rating = 8.5f,
                            Description = Terminator,
                            Duration = "2, 17, 08",
                            TitleImage = _01,
                            ReleaseDate = "1991, 1, 1",
                            CategoryId = 1
                        },
                        new MainRecordData()
                        {
                            Id = 2,
                            Rating = 7.2f,
                            Description = Inferno,
                            Duration = "1, 45, 22",
                            TitleImage = _02,
                            ReleaseDate = "1999, 1, 1",
                            CategoryId = 1
                        },
                        new MainRecordData()
                        {
                            Id = 3,
                            Rating = 7.5f,
                            Description = LittleMonsters,
                            Duration = "1, 33, 43",
                            TitleImage = _03,
                            ReleaseDate = "2019, 1, 1",
                            CategoryId = 1
                        },
                        new MainRecordData()
                        {
                            Id = 4,
                            Rating = 9.3f,
                            Description = Batman,
                            Duration = "1, 22, 06",
                            TitleImage = _04,
                            ReleaseDate = "2019, 1, 1",
                            CategoryId = 2
                        },
                        new MainRecordData()
                        {
                            Id = 5,
                            Rating = 9.4f,
                            Description = BlackFox,
                            Duration = "1, 30, 00",
                            TitleImage = _05,
                            ReleaseDate = "2019, 10, 5",
                            CategoryId = 2
                        },
                        new MainRecordData()
                        {
                            Id = 6,
                            Rating = 9.8f,
                            Description = Pokemon,
                            Duration = "0, 21, 00",
                            TitleImage = _06,
                            ReleaseDate = "2013, 1, 1",
                            CategoryId = 3
                        }
                    }
                );
        }
    }
}
