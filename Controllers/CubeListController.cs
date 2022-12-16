using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserLevels.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CubeListController : ControllerBase
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IMapper _mapper;

        public CubeListController(ApplicationDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<CubeListReadDTO>> GetAllCubeLists()
        {
            var listOfCubeLists= _context.CubeLists.Include(c=>c.Cubes).ToList();
            List<CubeListReadDTO> resultList = new List<CubeListReadDTO>();
            foreach(var cubeList in listOfCubeLists)
            {
                var cubeListDto = new CubeListReadDTO();
                var cubesDTO = new List<CubeDTO>();
                foreach(Cube cube in cubeList.Cubes)
                {
                    cubesDTO.Add(new CubeDTO(cube.X, cube.Y));
                    //cubesDTO.Add(_mapper.Map<CubeDTO>(cube));
                }
                cubeListDto.Cubes = cubesDTO;
                cubeListDto.Name = cubeList.Name;
                resultList.Add(cubeListDto);
            }
            return resultList;
        }

        [HttpGet("{Id}")]
        public ActionResult<CubeList> GetCubeListById([FromRoute] Guid Id)
        {
           return _context.CubeLists.Find(Id);
        }

        [HttpPost]
        public ActionResult<CubeList> CreateCubeList([FromBody] CubeListWriteDTO cubeListWriteDTO)
        {
            CubeList cubeList = new CubeList();
            
            var cubes = new List<Cube>();
            foreach(var cubeDto in cubeListWriteDTO.Cubes)
            {
                var cube = new Cube();
                cube.X = cubeDto.X;
                cube.Y = cubeDto.Y;
                cube.CubeListId = cubeList.Id;
                cubes.Add(cube);
            }
            cubeList.Name = cubeListWriteDTO.Name;
            cubeList.Cubes = cubes;

            _context.CubeLists.Add(cubeList);
            _context.SaveChanges();

            return Ok();
        }
    }
}