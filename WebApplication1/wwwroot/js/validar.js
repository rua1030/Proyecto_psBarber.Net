eliminarUsuario = () => {

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            swalWithBootstrapButtons.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            )
        }
    })
}
// validacion de nombres
validarUsuarios = () => {

    let nombres = document.getElementById("nombres").value;
    let pass = document.getElementById("pass").value;
    let email = document.getElementById("email").value;
    let id_rol = document.getElementById("id_rol").value;


    if (nombres == "" || pass == "" || email == "" || id_rol == "") {
        Swal.fire({
            icon: 'error',
            title: 'Campos Vacios',
            text: 'Por favor ingresar datos!',

        })
    } else if ((!Caracteres.test(nombres))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en nombres',
            text: 'Por favor ingresar solo letras!',

        })
    } else if ((!Caracteres.test(pass))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en cantidad',
            text: 'Por favor ingresar contraseña!',

        })
    } else if ((!Caracteres.test(email))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en precio',
            text: 'Por favor ingresar email',

        })
    } else if ((!Number.isInteger(id_rol))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en precio',
            text: 'Por favor ingresar email',

        })
    } else {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Confirmar en envio del formulario?',
            text: "¡No podrás revertir esto!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Aceptar!',
            cancelButtonText: 'Cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {

                const nombres = new nombres.getElementById('nombres');
                nombres.submit();
                swalWithBootstrapButtons.fire(
                    'Registro Enviado!',
                    'Your file has been deleted.',
                    'success'
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Se cancelo el envio',
                    'Your imaginary file is safe :)',
                    'error'
                )
            }
        })
    }
}


validarUsuariosA = () => {

    let nombres = document.getElementById("nombres").value;
    let pass = document.getElementById("pass").value;
    let email = document.getElementById("email").value;



    if (nombres == "" || pass == "" || email == "" || id_rol == "") {
        Swal.fire({
            icon: 'error',
            title: 'Campos Vacios',
            text: 'Por favor ingresar datos!',

        })
    } else if ((!Caracteres.test(nombres))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en nombres',
            text: 'Por favor ingresar solo letras!',

        })
    } else if ((!Caracteres.test(pass))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en cantidad',
            text: 'Por favor ingresar contraseña!',

        })
    } else if ((!Caracteres.test(email))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en precio',
            text: 'Por favor ingresar email',

        })
    } else if ((!Number.isInteger(id_rol))) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inavalidos en precio',
            text: 'Por favor ingresar email',

        })
    } else {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: 'Confirmar en envio del formulario?',
            text: "¡No podrás revertir esto!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Aceptar!',
            cancelButtonText: 'Cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {

                const nombres = new nombres.getElementById('nombres');
                nombres.submit();
                swalWithBootstrapButtons.fire(
                    'Registro Enviado!',
                    'Your file has been deleted.',
                    'success'
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'Se cancelo el envio',
                    'Your imaginary file is safe :)',
                    'error'
                )
            }
        })
    }
}



validarCliente = () => {
    let nombre = document.getElementById("nombre").value;
    let telefono = document.getElementById("telefono").value;
    let email = document.getElementById("email").value;
    let documento = document.getElementById("documento").value;

    if (nombre === "" || telefono === "" || documento === "" || email === "") {
        Swal.fire({
            icon: 'error',
            title: 'Campos Vacios',
            text: 'Por favor ingresar datos!'
        });
    } else if (!Caracteres.test(nombre)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en nombres',
            text: 'Por favor ingresar solo letras!'
        });
    } else if (!Caracteres.test(telefono)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en cantidad',
            text: 'Por favor ingresar número de teléfono!'
        });
    } else if (!Caracteres.test(documento)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en documento',
            text: 'Por favor ingresar documento válido!'
        });
    } else if (!Caracteres.test(email)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en email',
            text: 'Por favor ingresar email válido!'
        });
    } else {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: 'Confirmar envío del formulario?',
            text: '¡No podrás revertir esto!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Aceptar!',
            cancelButtonText: 'Cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                const form = document.getElementById('formCliente');
                form.submit();
                swalWithBootstrapButtons.fire(
                    'Registro Enviado!',
                    'El formulario ha sido enviado.',
                    'success'
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire(
                    'Se canceló el envío',
                    'Tu formulario no ha sido enviado.',
                    'error'
                );
            }
        });
    }
}

validarVenta = () => {
    let id_Cliente = document.getElementById("id_cliente");
    let total = document.getElementById("total");
    let fecha = document.getElementById("datepicker");

    if (id_Cliente.value === "" || total.value === "" || fecha.value === "") {
        Swal.fire({
            icon: 'error',
            title: 'Campos Vacios',
            text: 'Por favor ingresar datos!'
        });
    } else if (!Caracteres.test(id_Cliente.value)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en nombres',
            text: 'Por favor ingresar solo letras!'
        });
    } else if (!Caracteres.test(total.value)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en cantidad',
            text: 'Por favor ingresar número de teléfono!'
        });
    } else if (!Caracteres.test(fecha.value)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en documento',
            text: 'Por favor ingresar documento válido!'
        });
    } else {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: 'Confirmar envío del formulario?',
            text: '¡No podrás revertir esto!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Aceptar!',
            cancelButtonText: 'Cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                const form = document.getElementById('formVenta');
                form.submit();
                swalWithBootstrapButtons.fire(
                    'Registro Enviado!',
                    'El formulario ha sido enviado.',
                    'success'
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire(
                    'Se canceló el envío',
                    'Tu formulario no ha sido enviado.',
                    'error'
                );
            }
        });
    }
}

validarVentaA = () => {
    let id_Cliente = document.getElementById("id_Cliente");
    let total = document.getElementById("total");
    let fecha = document.getElementById("datepicker");

    if (!id_Cliente || !total || !fecha) {
        Swal.fire({
            icon: 'error',
            title: 'Elementos no encontrados',
            text: 'No se encontraron elementos requeridos en el formulario.'
        });
        return; // Detener la ejecución si falta algún elemento
    }

    if (id_Cliente.value === "" || total.value === "" || fecha.value === "") {
        Swal.fire({
            icon: 'error',
            title: 'Campos Vacios',
            text: 'Por favor ingresar datos!'
        });
    } else if (!Caracteres.test(id_Cliente.value)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en nombres',
            text: 'Por favor ingresar solo letras!'
        });
    } else if (!Caracteres.test(total.value)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en cantidad',
            text: 'Por favor ingresar número de teléfono!'
        });
    } else if (!Caracteres.test(fecha.value)) {
        Swal.fire({
            icon: 'error',
            title: 'Datos inválidos en documento',
            text: 'Por favor ingresar documento válido!'
        });
    } else {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: 'Confirmar envío del formulario?',
            text: '¡No podrás revertir esto!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Aceptar!',
            cancelButtonText: 'Cancelar!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                const form = document.getElementById('formVenta');
                form.submit();
                swalWithBootstrapButtons.fire(
                    'Registro Enviado!',
                    'El formulario ha sido enviado.',
                    'success'
                );
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire(
                    'Se canceló el envío',
                    'Tu formulario no ha sido enviado.',
                    'error'
                );
            }
        });
    }
}
