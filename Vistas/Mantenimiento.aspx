<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Mantenimiento.aspx.cs"
    Inherits="WebAgenda.Vistas.Mantenimiento" %>

<%--
    Directiva principal de la página ASP.NET Web Forms.

    Language:
        Indica el lenguaje utilizado en el archivo de código.

    AutoEventWireup:
        Permite que los eventos de la página se conecten automáticamente.

    CodeBehind:
        Especifica el archivo que contiene la lógica C# de la página.

    Inherits:
        Indica la clase a la que pertenece esta página.
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <%-- Permite utilizar caracteres especiales como tildes y ñ --%>
    <meta charset="utf-8" />

    <%-- Título que se mostrará en la pestaña del navegador --%>
    <title>Mantenimiento de Contactos</title>

    <%-- Enlaza el archivo CSS que contiene los estilos visuales        de la página.--%>
    <link
        href="Estilos.css"
        rel="stylesheet"
        type="text/css" />

</head>

<body>

    <%--
        Formulario principal de ASP.NET Web Forms.

        runat="server" permite que los controles internos
        sean procesados por el servidor.
    --%>
    <form
        id="form1"
        runat="server">

        <%--            Contenedor general de toda la página.        --%>
        <div class="pagina">

            <%--                Encabezado de la aplicación.            --%>
            <div class="encabezado">

                <%-- Título principal de la página --%>
                <h1>Agenda de Contactos</h1>

                <%-- Descripción de la funcionalidad --%>
                <p>
                    Mantenimiento de contactos registrados
                </p>

            </div>

            <%-- Label utilizado para mostrar mensajes al usuario.

                Visible="false":
                    Inicialmente el mensaje permanece oculto.

                El archivo Mantenimiento.aspx.cs puede modificar
                su texto y visibilidad mediante lblMensaje.
            --%>
            <asp:Label
                ID="lblMensaje"
                runat="server"
                CssClass="mensaje"
                Visible="false">
            </asp:Label>

            <%--
                Campo oculto utilizado para almacenar el ID
                del contacto que se está editando.

                Si este campo está vacío, se crea un contacto nuevo.
                Si contiene un ID, se actualiza ese contacto.
            --%>
            <asp:HiddenField
                ID="hfIdContacto"
                runat="server" />

            <%-- Contenedor que agrupa el formulario y el listado de contactos. --%>
            <div class="contenedor">

                <%--==========================================================
                    FORMULARIO DE CONTACTOS
                ===========================================================--%>

                <div class="tarjeta formulario">

                    <%--
                        Título dinámico del formulario.

                        Puede mostrar:
                            - Nuevo contacto
                            - Editar contacto

                        El texto se modifica desde el archivo C#.
                    --%>
                    <asp:Label
                        ID="lblTituloFormulario"
                        runat="server"
                        CssClass="titulo-formulario"
                        Text="Nuevo contacto">
                    </asp:Label>

                    <%--======================================================
                        CAMPO NOMBRE
                    =======================================================--%>

                    <div class="grupo">

                        <%-- Etiqueta visual del campo nombre --%>
                        <label for="txtNombre">
                            Nombre
                            <span class="obligatorio">*</span>
                        </label>

                        <%--
                            TextBox para ingresar el nombre.

                            MaxLength="100":
                                Permite como máximo 100 caracteres.
                        --%>
                        <asp:TextBox
                            ID="txtNombre"
                            runat="server"
                            CssClass="entrada"
                            MaxLength="100">
                        </asp:TextBox>

                        <%--
                            Validador que obliga al usuario
                            a ingresar un nombre.

                            ControlToValidate:
                                Indica qué TextBox se debe validar.

                            Display="Dynamic":
                                El mensaje solo ocupa espacio
                                cuando existe un error.
                        --%>
                        <asp:RequiredFieldValidator
                            ID="rfvNombre"
                            runat="server"
                            ControlToValidate="txtNombre"
                            ErrorMessage="El nombre es obligatorio."
                            CssClass="error"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>

                    </div>

                    <%--======================================================
                        CAMPO APELLIDO
                    =======================================================--%>

                    <div class="grupo">

                        <%-- Etiqueta visual del campo apellido --%>
                        <label for="txtApellido">
                            Apellido
                            <span class="obligatorio">*</span>
                        </label>

                        <%-- TextBox para ingresar el apellido. --%>
                        <asp:TextBox
                            ID="txtApellido"
                            runat="server"
                            CssClass="entrada"
                            MaxLength="100">
                        </asp:TextBox>

                        <%-- Validador que verifica que el apellido no se encuentre vacío. --%>
                        <asp:RequiredFieldValidator
                            ID="rfvApellido"
                            runat="server"
                            ControlToValidate="txtApellido"
                            ErrorMessage="El apellido es obligatorio."
                            CssClass="error"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>

                    </div>

                    <%--======================================================
                        CAMPO TELÉFONO
                    =======================================================--%>

                    <div class="grupo">

                        <%-- Campo opcional para el número telefónico --%>
                        <label for="txtTelefono">
                            Teléfono
                        </label>

                        <asp:TextBox
                            ID="txtTelefono"
                            runat="server"
                            CssClass="entrada"
                            MaxLength="30">
                        </asp:TextBox>

                    </div>

                    <%--======================================================
                        CAMPO CORREO
                    =======================================================--%>

                    <div class="grupo">

                        <%-- Campo opcional para el correo electrónico --%>
                        <label for="txtCorreo">
                            Correo
                        </label>

                        <%-- TextMode="Email": Genera un campo de tipo correo electrónico en el navegador. --%>
                        <asp:TextBox
                            ID="txtCorreo"
                            runat="server"
                            CssClass="entrada"
                            MaxLength="150"
                            TextMode="Email">
                        </asp:TextBox>

                    </div>

                    <%--======================================================
                        CAMPO USUARIO
                    =======================================================--%>

                    <div class="grupo">

                        <%-- Usuario que crea o modifica el contacto --%>
                        <label for="txtUsuario">
                            Usuario
                        </label>

                        <%-- Text="admin": Establece "admin" como valor inicial. --%>
                        <asp:TextBox
                            ID="txtUsuario"
                            runat="server"
                            CssClass="entrada"
                            MaxLength="50"
                            Text="admin">
                        </asp:TextBox>

                    </div>

                    <%--======================================================
                        BOTONES DEL FORMULARIO
                    =======================================================--%>

                    <div class="botones">

                        <%--
                            Botón utilizado para crear o actualizar
                            un contacto.

                            OnClick:
                                Ejecuta el método btnGuardar_Click
                                ubicado en Mantenimiento.aspx.cs.
                        --%>
                        <asp:Button
                            ID="btnGuardar"
                            runat="server"
                            Text="Guardar"
                            CssClass="boton boton-primario"
                            OnClick="btnGuardar_Click"></asp:Button>

                        <%--
                            Botón para limpiar el formulario.

                            CausesValidation="false":
                                Evita que se ejecuten los validadores
                                de nombre y apellido.

                            OnClick:
                                Ejecuta el método btnNuevo_Click.
                        --%>
                        <asp:Button
                            ID="btnNuevo"
                            runat="server"
                            Text="Limpiar"
                            CssClass="boton boton-secundario"
                            CausesValidation="false"
                            OnClick="btnNuevo_Click"></asp:Button>

                    </div>

                </div>

                <%--==========================================================
                    CONSULTA Y LISTADO DE CONTACTOS
                ===========================================================--%>

                <div class="tarjeta listado">

                    <%-- Título de la sección del listado --%>
                    <h2>Contactos registrados</h2>

                    <%--======================================================
                        SECCIÓN DE BÚSQUEDA
                    =======================================================--%>

                    <div class="busqueda">

                        <%-- Lista desplegable para seleccionar el tipo de búsqueda. --%>
                        <asp:DropDownList
                            ID="ddlFiltro"
                            runat="server"
                            CssClass="selector">

                            <%-- Opción para mostrar todos los contactos. --%>
                            <asp:ListItem
                                Text="Todos los contactos"
                                Value="TODOS">
                            </asp:ListItem>

                            <%-- Opción para buscar por teléfono. --%>
                            <asp:ListItem
                                Text="Buscar por teléfono"
                                Value="TELEFONO">
                            </asp:ListItem>

                            <%-- Opción para buscar por correo. --%>
                            <asp:ListItem
                                Text="Buscar por correo"
                                Value="CORREO">
                            </asp:ListItem>

                        </asp:DropDownList>

                        <%-- Campo donde el usuario escribe el valor que desea buscar. --%>
                        <asp:TextBox
                            ID="txtBuscar"
                            runat="server"
                            CssClass="entrada"
                            placeholder="Ingrese el valor a buscar">
                        </asp:TextBox>

                        <%--
                            Ejecuta la búsqueda de contactos.

                            CausesValidation="false":
                                La búsqueda no requiere validar
                                los campos del formulario principal.

                            OnClick:
                                Ejecuta btnBuscar_Click.
                        --%>
                        <asp:Button
                            ID="btnBuscar"
                            runat="server"
                            Text="Buscar"
                            CssClass="boton boton-primario"
                            CausesValidation="false"
                            OnClick="btnBuscar_Click"></asp:Button>

                    </div>

                    <%--======================================================
                        TABLA DE CONTACTOS
                    =======================================================--%>

                    <div class="tabla-contenedor">

                        <%--
                            GridView que muestra los contactos.

                            AutoGenerateColumns="false":
                                Las columnas se definen manualmente.

                            DataKeyNames:
                                Indica el campo que identifica
                                de forma única cada registro.

                            EmptyDataText:
                                Mensaje mostrado cuando no existen datos.

                            OnRowCommand:
                                Ejecuta el método que controla las acciones
                                de editar y eliminar.
                        --%>
                        <asp:GridView
                            ID="gvContactos"
                            runat="server"
                            AutoGenerateColumns="false"
                            CssClass="tabla"
                            GridLines="None"
                            DataKeyNames="ID_CONTACTO"
                            EmptyDataText="No hay contactos registrados."
                            OnRowCommand="gvContactos_RowCommand">

                            <Columns>
                                <%--================================================
                                    COLUMNA ID
                                =================================================--%>
                                <asp:BoundField
                                    DataField="ID_CONTACTO"
                                    HeaderText="ID" />
                                <%--================================================
                                    COLUMNA NOMBRE
                                =================================================--%>
                                <asp:BoundField
                                    DataField="NOMBRE"
                                    HeaderText="Nombre" />
                                <%--================================================
                                    COLUMNA APELLIDO
                                =================================================--%>
                                <asp:BoundField
                                    DataField="APELLIDO"
                                    HeaderText="Apellido" />
                                <%--================================================
                                    COLUMNA TELÉFONO
                                =================================================--%>

                                <asp:BoundField
                                    DataField="TELEFONO"
                                    HeaderText="Teléfono" />
                                <%--================================================
                                    COLUMNA CORREO
                                =================================================--%>

                                <asp:BoundField
                                    DataField="CORREO"
                                    HeaderText="Correo" />
                                <%--================================================
                                    USUARIO QUE AGREGÓ EL CONTACTO
                                =================================================--%>
                                <asp:BoundField
                                    DataField="ADICIONADO_POR"
                                    HeaderText="Adicionado por" />
                                <%--================================================
                                    FECHA DE ADICIÓN
                                =================================================--%>
                                <%--
                                    DataFormatString:
                                        Da formato a la fecha recibida.

                                    dd/MM/yyyy HH:mm representa:
                                        Día/Mes/Año Hora:Minutos
                                --%>
                                <asp:BoundField
                                    DataField="FECHA_ADICION"
                                    HeaderText="Fecha de adición"
                                    DataFormatString="{0:dd/MM/yyyy HH:mm}" />

                                <%--================================================
                                    COLUMNA DE ACCIONES
                                =================================================--%>
                                <%-- TemplateField permite insertar controles personalizados dentro de cada fila. --%>
                                <asp:TemplateField
                                    HeaderText="Acciones">

                                    <ItemTemplate>

                                        <%-- Contenedor visual de los botones --%>
                                        <div class="acciones">
                                            <%--================================================
                                                BOTÓN EDITAR
                                            =================================================--%>
                                            <%--
                                                LinkButton que permite editar
                                                el contacto seleccionado.

                                                CommandName:
                                                    Nombre de la acción enviada
                                                    al evento RowCommand.

                                                CommandArgument:
                                                    Envía el ID del contacto.

                                                Eval:
                                                    Obtiene el valor del campo
                                                    ID_CONTACTO de la fila actual.
                                            --%>
                                            <asp:LinkButton
                                                ID="btnEditar"
                                                runat="server"
                                                Text="Editar"
                                                CssClass="boton boton-editar"
                                                CommandName="EditarContacto"
                                                CommandArgument='<%# Eval("ID_CONTACTO") %>'
                                                CausesValidation="false">
                                            </asp:LinkButton>

                                            <%--================================================
                                                BOTÓN ELIMINAR
                                            =================================================--%>
                                            <%--
                                                LinkButton que permite eliminar
                                                el contacto seleccionado.

                                                OnClientClick:
                                                    Muestra una confirmación
                                                    antes de continuar.

                                                Si el usuario selecciona Cancelar,
                                                la operación no se ejecuta.
                                            --%>
                                            <asp:LinkButton
                                                ID="btnEliminar"
                                                runat="server"
                                                Text="Eliminar"
                                                CssClass="boton boton-peligro"
                                                CommandName="EliminarContacto"
                                                CommandArgument='<%# Eval("ID_CONTACTO") %>'
                                                CausesValidation="false"
                                                OnClientClick="return confirm('¿Está seguro de eliminar este contacto?');">
                                            </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
