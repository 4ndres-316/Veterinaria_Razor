using gestion_veterinaria.Models;

namespace gestion_veterinaria.Data
{
    public class DataStore
    {
        public List<Propietario> Propietarios { get; } = new();
        public List<Mascota> Mascotas { get; } = new();
        public List<Veterinario> Veterinarios { get; } = new();
        public List<Cita> Citas { get; } = new();

        private int _nextPropietarioId = 1;
        private int _nextMascotaId = 1;
        private int _nextVeterinarioId = 1;
        private int _nextCitaId = 1;

        public int SiguientePropietarioId() => _nextPropietarioId++;
        public int SiguienteMascotaId() => _nextMascotaId++;
        public int SiguienteVeterinarioId() => _nextVeterinarioId++;
        public int SiguienteCitaId() => _nextCitaId++;
    }
}