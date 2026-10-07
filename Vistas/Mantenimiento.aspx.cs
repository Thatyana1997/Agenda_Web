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
                List<Contactos> contactos = _repositorio.ConsultarTodos();

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

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            // Verifica que todos los controles de validación
            // de la página sean correctos
            if (!Page.IsValid)
            {
                // Si existe algún error de validación,
                // se detiene la ejecución del método
                return;
            }

            try
            {
                // Se crea un objeto Contactos con la información
                // ingresada por el usuario
                Contactos contacto = new Contactos
                {
                    // Trim elimina espacios al inicio y al final
                    NOMBRE = txtNombre.Text.Trim(),
                    APELLIDO = txtApellido.Text.Trim(),
                    TELEFONO = txtTelefono.Text.Trim(),
                    CORREO = txtCorreo.Text.Trim()
                };

                // Si el campo oculto contiene un ID,
                // significa que se está editando un contacto existente
                bool esEdicion =
                    !string.IsNullOrWhiteSpace(
                        hfIdContacto.Value);

                if (esEdicion)
                {
                    // Convierte el valor del campo oculto a número
                    // y lo asigna al contacto que será actualizado
                    contacto.ID_CONTACTO =
                        Convert.ToInt32(hfIdContacto.Value);

                    // Registra el usuario que realizó la modificación
                    contacto.MODIFICADO_POR =
                        txtUsuario.Text.Trim();

                    // Actualiza el contacto en la base de datos
                    _repositorio.Actualizar(contacto);

                    // Informa al usuario que la operación fue exitosa
                    MostrarMensaje(
                        "El contacto fue actualizado correctamente.");
                }
                else
                {
                    // Registra el usuario que creó el contacto
                    contacto.ADICIONADO_POR =
                        txtUsuario.Text.Trim();

                    // Inserta el nuevo contacto en la base de datos
                    _repositorio.Crear(contacto);

                    // Informa al usuario que la operación fue exitosa
                    MostrarMensaje(
                        "El contacto fue creado correctamente.");
                }

                // Limpia los campos del formulario
                LimpiarFormulario();

                // Actualiza la lista de contactos mostrada
                CargarContactos();
            }
            catch (Exception ex)
            {
                // Captura cualquier error ocurrido durante el guardado
                MostrarMensaje(
                    "Error al guardar el contacto: " + ex.Message);
            }
        }

        // Evento ejecutado cuando el usuario presiona el botón Nuevo
        protected void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // Limpia todos los campos del formulario
            LimpiarFormulario();

            // Oculta cualquier mensaje que estuviera visible
            OcultarMensaje();
        }

        // Evento ejecutado cuando el usuario presiona el botón Buscar
        protected void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // Variable que almacenará los resultados de la búsqueda
                List<Contactos> contactos;

                // Obtiene el criterio seleccionado en el DropDownList
                string filtro = ddlFiltro.SelectedValue;

                // Obtiene el texto escrito por el usuario
                string texto = txtBuscar.Text.Trim();

                // Consulta por número de teléfono
                if (filtro == "TELEFONO")
                {
                    contactos =
                        _repositorio.ConsultarPorTelefono(texto);
                }
                // Consulta por correo electrónico
                else if (filtro == "CORREO")
                {
                    contactos =
                        _repositorio.ConsultarPorCorreo(texto);
                }
                // Si no se selecciona un filtro específico,
                // se consultan todos los contactos
                else
                {
                    contactos =
                        _repositorio.ConsultarTodos();
                }

                // Muestra los resultados en el GridView
                gvContactos.DataSource = contactos;
                gvContactos.DataBind();
            }
            catch (Exception ex)
            {
                // Muestra el error si la búsqueda falla
                MostrarMensaje(
                    "Error al realizar la búsqueda: " + ex.Message);
            }
        }

        // Evento ejecutado cuando se presiona un botón dentro del GridView
        protected void gvContactos_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            try
            {
                // Obtiene el ID del contacto enviado
                // mediante el CommandArgument del botón
                int idContacto =
                    Convert.ToInt32(e.CommandArgument);

                // Verifica si la acción solicitada es editar
                if (e.CommandName == "EditarContacto")
                {
                    // Carga los datos del contacto en el formulario
                    CargarContactoParaEditar(idContacto);
                }
                // Verifica si la acción solicitada es eliminar
                else if (e.CommandName == "EliminarContacto")
                {
                    // Elimina el contacto de la base de datos
                    _repositorio.Eliminar(idContacto);

                    // Informa al usuario que el contacto fue eliminado
                    MostrarMensaje(
                        "El contacto fue eliminado correctamente.");

                    // Actualiza la lista de contactos
                    CargarContactos();
                }
            }
            catch (Exception ex)
            {
                // Captura errores ocurridos durante la edición
                // o eliminación de un contacto
                MostrarMensaje(
                    "Error al procesar la operación: " + ex.Message);
            }
        }

        // Busca un contacto por su ID y carga sus datos
        // en los controles del formulario
        private void CargarContactoParaEditar(
            int idContacto)
        {
            // Consulta todos los contactos disponibles
            List<Contactos> contactos =
                _repositorio.ConsultarTodos();

            // Busca dentro de la lista el contacto cuyo ID coincida
            Contactos contacto =
                contactos.Find(x =>
                    x.ID_CONTACTO == idContacto);

            // Si no se encuentra el contacto,
            // se muestra un mensaje y se detiene el método
            if (contacto == null)
            {
                MostrarMensaje(
                    "No se encontró el contacto seleccionado.");

                return;
            }

            // Guarda el ID del contacto en un campo oculto
            // para identificarlo al momento de actualizar
            hfIdContacto.Value =
                contacto.ID_CONTACTO.ToString();

            // Carga los datos del contacto en el formulario
            txtNombre.Text =
                contacto.NOMBRE;

            txtApellido.Text =
                contacto.APELLIDO;

            txtTelefono.Text =
                contacto.TELEFONO;

            txtCorreo.Text =
                contacto.CORREO;

            // Muestra el usuario que modificó el contacto.
            // Si no existe, muestra el usuario que lo creó
            txtUsuario.Text =
                contacto.MODIFICADO_POR
                ?? contacto.ADICIONADO_POR;

            // Cambia el título del formulario
            // para indicar que se está editando
            lblTituloFormulario.Text =
                "Editar contacto";

            // Cambia el texto del botón
            btnGuardar.Text =
                "Actualizar";
        }

        // Restablece el formulario a su estado inicial
        private void LimpiarFormulario()
        {
            // Limpia el ID oculto.
            // Al quedar vacío, el próximo guardado será una inserción
            hfIdContacto.Value = string.Empty;

            // Limpia los campos de texto
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;

            // Establece un usuario predeterminado
            txtUsuario.Text = "admin";

            // Restablece el título del formulario
            lblTituloFormulario.Text =
                "Nuevo contacto";

            // Restablece el texto del botón
            btnGuardar.Text =
                "Guardar";
        }

        // Muestra un mensaje en la interfaz
        private void MostrarMensaje(string mensaje)
        {
            // Asigna el texto recibido al Label
            lblMensaje.Text = mensaje;

            // Hace visible el Label
            lblMensaje.Visible = true;
        }

        // Oculta y limpia el mensaje mostrado
        private void OcultarMensaje()
        {
            // Elimina el texto del mensaje
            lblMensaje.Text = string.Empty;

            // Oculta el Label
            lblMensaje.Visible = false;
        }
    }
}