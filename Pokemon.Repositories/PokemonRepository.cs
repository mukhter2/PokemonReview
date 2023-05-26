using PokemonReview.Datas;
using PokemonReview.Interfaces;
using PokemonReview.Models.Models;

namespace PokemonReview.Repositories
{
    public class PokemonRepository : IPokemon
    {
        private readonly DataContext _context; 

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Id == pokeId);

            if (review.Count() <= 0)
            {
                return 0;
            }
            return review.Sum(r=> r.Rating) / review.Count();


        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemons.Any(r => r.Id == pokeId); 
        }
    }
}