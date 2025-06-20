using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ClientePuntoDeVenta.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace ClientePuntoDeVenta.Vistas
{
    public class AgregarProductoViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly InventarioCliente _servicio = new();
        private string _nombre;
        private int _cantidad;
        private decimal _precio;
        private readonly Dictionary<string, List<string>> _errors = new();

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged();
                    ValidateNombre();
                }
            }
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged();
                    ValidateCantidad();
                }
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (_precio != value)
                {
                    _precio = value;
                    OnPropertyChanged();
                    ValidatePrecio();
                }
            }
        }

        #region Validaciones

        private void ValidateNombre()
        {
            const int maxLength = 100;
            ClearErrors(nameof(Nombre));

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                AddError(nameof(Nombre), "El nombre es requerido");
            }
            else if (Nombre.Length > maxLength)
            {
                AddError(nameof(Nombre), $"El nombre no puede exceder {maxLength} caracteres");
            }
            else if (Nombre.Any(char.IsDigit))
            {
                AddError(nameof(Nombre), "El nombre no debe contener números");
            }
        }

        private void ValidateCantidad()
        {
            const int maxCantidad = 10000;
            ClearErrors(nameof(Cantidad));

            if (Cantidad < 0)
            {
                AddError(nameof(Cantidad), "La cantidad no puede ser negativa");
            }
            else if (Cantidad > maxCantidad)
            {
                AddError(nameof(Cantidad), $"La cantidad no puede exceder {maxCantidad:N0} unidades");
            }
        }

        private void ValidatePrecio()
        {
            const decimal maxPrecio = 999999.99m;
            ClearErrors(nameof(Precio));

            if (Precio < 0)
            {
                AddError(nameof(Precio), "El precio no puede ser negativo");
            }
            else if (Precio > maxPrecio)
            {
                AddError(nameof(Precio), $"El precio no puede exceder {maxPrecio:C}");
            }
            else if (Decimal.Round(Precio, 2) != Precio)
            {
                AddError(nameof(Precio), "El precio no puede tener más de 2 decimales");
            }
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        #endregion

        public async Task AgregarProductoAsync()
        {
            // Validar todos los campos antes de proceder
            ValidateNombre();
            ValidateCantidad();
            ValidatePrecio();

            if (HasErrors)
            {
                var errorMessage = string.Join(Environment.NewLine,
                    _errors.Values.SelectMany(errors => errors));

                MessageBox.Show($"Por favor corrija los siguientes errores antes de continuar:{Environment.NewLine}{Environment.NewLine}{errorMessage}",
                    "Error de validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var producto = new ProductoDto
            {
                Nombre = this.Nombre?.Trim(),
                Cantidad = this.Cantidad,
                Precio = this.Precio
            };

            try
            {
                await _servicio.CrearProductoAsync(producto);
                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimpiarCampos()
        {
            Nombre = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }

        #region INotifyDataErrorInfo Members

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return _errors.Values.SelectMany(errors => errors);
            }

            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : Enumerable.Empty<string>();
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        #endregion
    }
}