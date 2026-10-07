// Importa clases básicas del lenguaje C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Clases necesarias para trabajar con páginas ASP.NET Web Forms
using System.Web.UI;
using System.Web.UI.WebControls;

// Espacios de nombres propios del proyecto
using WebAgenda.Modelos;
using WebAgenda.Repositorios;

namespace WebAgenda.Vistas
{// Clase parcial asociada a la página Mantenimiento.aspx
    public partial class Mantenimiento : System.Web.UI.Page
    {
        // Instancia del repositorio encargado de realizar
        // las operaciones de base de datos relacionadas con contactos
        private readonly ContactoRepositorio _repositorio = new ContactoRepositorio();

        // Este método se ejecuta cada vez que se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // IsPostBack permite saber si la página se está cargando
            // por primera vez o como resultado de una acción del usuario
            if (!IsPostBack)
            {
                // Carga la lista de contactos solamente la primera vez
                CargarContactos();
            }
        }

        // Obtiene todos los contactos desde el repositorio
        // y los muestra en el GridView
        private void CargarContactos()
        {
            try
            {
                // Consulta todos los contactos almacenados
                List<Contactos> contactos =
                    _repositorio.ConsultarTodos();
                // Asigna la lista como origen de datos del GridView
                gvContactos.DataSource = contactos;
                // Enlaza los datos con el control visual
                gvContactos.DataBind();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, se muestra un mensaje al usuario
                MostrarMensaje(
                    "Error al cargar los contactos: " + ex.Message);
            }
        }

        // Evento ejecutado cuando el usuario presiona el botón Guardar
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
             
        }

        // Evento ejecutado cuando el usuario presiona el botón Nuevo
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        // Evento ejecutado cuando el usuario presiona el botón Buscar
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        // Evento ejecutado cuando se presiona un botón dentro del GridView
        protected void gvContactos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        // Busca un contacto por su ID y carga sus datos
        // en los controles del formulario
        private void CargarContactoParaEditar(int idContacto)
        {

        }

        // Restablece el formulario a su estado inicial
        private void LimpiarFormulario()
        {

        }

        // Muestra un mensaje en la interfaz
        private void MostrarMensaje(string mensaje)
        {

        }

        // Oculta y limpia el mensaje mostrado
        private void OcultarMensaje()
        {

        }
    }
}