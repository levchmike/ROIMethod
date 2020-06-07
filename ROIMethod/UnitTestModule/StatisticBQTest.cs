using AutoMapper;
using Moq;
using ROIMethod.Controllers.v1;
using ROIMethod.EndPointModels;
using ROIMethod.WebAPI.Core.CaseServices.Interface;
using ROIMethod.WebAPI.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTestModule
{
    public class StatisticBQTest
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatisticDTO, StatisticView>());
            var mapper = new Mapper(config);
            var mock = new Mock<IBQStatisticService>();
            mock.Setup(serv => serv.getAllStatistic()).Returns(GetTestStatistics());
            var controller = new StatisticBQController(mock.Object);
            var automapperResult = mapper.Map<List<StatisticView>>(controller.Get());
            var listObjs = Assert.IsAssignableFrom<IEnumerable<StatisticView>>(automapperResult);
            var model = Assert.IsAssignableFrom<IEnumerable<StatisticView>>(listObjs);
            Assert.Equal(GetTestStatistics().Count(), model.Count());
        }

        private IEnumerable<StatisticDTO> GetTestStatistics()
        {
            var sts = new List<StatisticDTO>
            {
                new StatisticDTO { Id=1, DescriptionInfo="GoogleAdwords", Clicks=35},
                new StatisticDTO { Id=2, DescriptionInfo="Yandex Metrics", Clicks=29}
            };
            return sts;
        }
    }
}
