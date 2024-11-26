﻿using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private Conexion? conexion = null;
        private AuditoriasRepositorio? auditoria = null;

        public ClientesRepositorio(Conexion conexion, AuditoriasRepositorio? auditoria)
        {
            this.conexion = conexion;
            this.auditoria = auditoria;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Clientes> Listar()
        {
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Clientes",
                "Select * from Clientes",
                "Se listaron todos los Clientes."
            );
            return conexion!.Listar<Clientes>();
        }
        public List<Clientes> Buscar(Expression<Func<Clientes, bool>> condiciones)
        {
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Clientes",
                "Select",
                $"Se lista en base a las condiciones: {condiciones}"
            );
            return conexion!.Buscar(condiciones);
        }
        public Clientes Guardar(Clientes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Clientes",
                "Insert",
                $"Se agregó un nuevo cliente: {entidad.Nombre} (Id: {entidad.Id})"
            );
            return entidad;
        }

        public Clientes Modificar(Clientes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Clientes",
                "Update",
                $"Se actualizó el cliente con Id: {entidad.Id}"
            );
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Clientes",
                "Delete",
                $"Se eliminó la mascota con Id: {entidad.Id}"
            );
            return entidad;
        }
    }
}
