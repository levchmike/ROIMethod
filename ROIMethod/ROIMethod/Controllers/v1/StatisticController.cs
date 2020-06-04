using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROIMethod.EndPointModels;
using ROIMethod.WebAPI.Core.CaseServices.Interface;
using ROIMethod.WebAPI.Core.DTO;

namespace ROIMethod.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        //ApplicationContext db;

        IStatisticService statisticService;
        public StatisticController(IStatisticService serv)
        {
            statisticService = serv;
        }

        [HttpGet]
        public IEnumerable<StatisticView> Get()
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatisticDTO, StatisticView>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var statistics = mapper.Map<List<StatisticView>>(statisticService.getAllStatistic());

            return statistics.ToList();

           // return statistics.ToList();
        }


    }
}