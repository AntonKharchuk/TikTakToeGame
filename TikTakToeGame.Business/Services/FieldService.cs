using TikTakToeGame.Entities;
using TikTakToeGame.Repositories;

namespace TikTakToeGame.Business.Services
{
    public class FieldService : IFieldService
    {
        private IGenericRepository<Field> _genericRepository;

        public FieldService(IGenericRepository<Field> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task CreateItemAsync()
        {
            var newField = new Field()
            {
                Positions = "0,0,0,0,0,0,0,0,0",
                StatusId = 1,
                TurnId = 1,
            };
            await _genericRepository.AddAsync(newField);
            await _genericRepository.SaveAsync();   
        }

        public async Task<IEnumerable<Field>> GetAllItemsAsync()
        {
            return await _genericRepository.GetAllAsync("Turn,Status");
        }

        public async Task<Field> GetItemByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id, "Turn,Status");
        }

        public async Task UpdatePlayersAsync(string newPlayersValue, int id)
        {
            var tableItem = await _genericRepository.GetByIdAsync(id);

            tableItem.Players = newPlayersValue;

            await _genericRepository.SaveAsync();
        }

        public async Task UpdateItemAsync(string positions, int id)
        {
            var tableItem =  await _genericRepository.GetByIdAsync(id);

            tableItem.Positions = positions;

            UpdateTurnAndStatus(tableItem);

            await _genericRepository.SaveAsync();
        }
        private void UpdateTurnAndStatus(Field field)
        {
            field.TurnId = field.TurnId == 1 ? 2 : 1;

            var positions = new int[9];
            
            var strMarks = field.Positions.Split(',');
            if (strMarks.Length != 9)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = int.Parse(strMarks[i]);
            }

            if (CheckForWin(positions, 1))
            {
                field.StatusId = 2;
                return;
            }
            if (CheckForWin(positions, 2))
            {
                field.StatusId = 3;
                return;
            }

            if (CheckForTie(positions))
            {
                field.StatusId = 4;
                return;
            }
        }
        private bool CheckForTie(int[] positions)
        {
            foreach (var mark in positions)
            {
                if (mark==0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckForWin(int[] positions, int mark)
        {
            for (int i = 0; i < 3; i++)
            {
                if (positions[i] == mark && positions[i+3] == mark && positions[i+6] == mark)
                {
                    return true;
                }
            }
            for (int i = 0; i < 8; i+=3)
            {
                if (positions[i] == mark && positions[i + 1] == mark && positions[i + 2] == mark)
                {
                    return true;
                }
            }
            if (positions[0] == mark && positions[4] == mark && positions[8] == mark)
            {
                return true;
            }
            if (positions[2] == mark && positions[4] == mark && positions[6] == mark)
            {
                return true;
            }
            return false;
        }

    }
}
