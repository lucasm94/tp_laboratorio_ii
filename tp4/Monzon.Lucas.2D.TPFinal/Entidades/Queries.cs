using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Queries
    {
        public const string GET_HINCHAS = "Select h.nombre, h.apellido, h.dni, h.nacimiento, h.sexo, h.activo, " +
            "c.nombre as club, es_socio from hincha h inner join club c on c.id=h.id_club " +
            "where h.activo = 1";
        public const string GET_CLUBES = "Select nombre from club";
        public const string EXISTE_HINCHA = "Select count(id) from hincha where activo=1 and dni=@dni";
        public const string GET_CANTIDAD_HINCHAS = "Select count(id) from hincha where activo=1";
        public const string GET_HINCHA_POR_DNI = "Select h.nombre, h.apellido, h.dni, h.nacimiento, h.sexo, h.activo, " +
            "c.nombre as club, es_socio from hincha h inner join club c on c.id=h.id_club " +
            "where h.activo = 1 and h.dni=@dni";
        public const string AGREGAR_HINCHA = "INSERT INTO hincha (nombre, apellido, dni, nacimiento, sexo, id_club, es_socio) " +
            "VALUES (@nombre, @apellido, @dni, @nacimiento, @sexo, " +
            "(select c.id from club c where c.nombre=@club), @es_socio)";
        public const string ACTUALIZAR_HINCHA = "UPDATE hincha set id_club=(select id from club where nombre=@club), " +
            "es_socio=@es_socio where dni=@dni";
        public const string BAJA_HINCHA = "UPDATE hincha set activo=0 where dni=@dni";
    }
}
