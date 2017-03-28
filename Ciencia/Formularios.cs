using Ciencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciencia
{

    public static class Formularios
    {
        private static frmMenu _fMenu;
        private static frmProceso _fProceso;
        private static frmActualizarModulo _fActualizarMod;

        private static frmSeguimientoAnualHemo _fSegAnualHemo;
        private static frmSeguimientoMul _fSegMul;
        public static frmSeguimientoMul  fSeguimientoMul
        {
            get
            {
                if (_fSegMul == null)
                {
                    _fSegMul = new frmSeguimientoMul();
                }
                return _fSegMul;
            }
        }
        public static frmSeguimientoAnualHemo fSegAnualHemo
        {
            get
            {
                if (_fSegAnualHemo == null)
                    _fSegAnualHemo = new frmSeguimientoAnualHemo();
                return _fSegAnualHemo;
            }
        }
        public static frmActualizarModulo fActualizarMod
        {
            get
            {
                if (_fActualizarMod == null || _fActualizarMod.IsDisposed)
                    _fActualizarMod = new frmActualizarModulo();
                return _fActualizarMod;
            }
        }
        public static frmProceso fProceso
        {
            get
            {
                if (_fProceso == null || _fProceso.IsDisposed)
                    _fProceso = new frmProceso();
                return _fProceso;
            }
        }
        public static frmMenu fMenu
        {
            get
            {
                if (_fMenu == null)
                    _fMenu = new frmMenu();
                return _fMenu;
            }
        }
        static frmSelector _fSelector;
        public static frmSelector fSelector
        {
            get
            {
                if (_fSelector == null || _fSelector.IsDisposed)
                    _fSelector = new frmSelector();
                return _fSelector;
            }
        }
        static frmComplemento _fcomplemento;
        public static  frmComplemento fComplemento
        {
            get
            {
                if(_fcomplemento== null || _fcomplemento.IsDisposed)
                    _fcomplemento= new frmComplemento();
                return _fcomplemento;
            }
        }

        private static frmEvolucion _fEvolucion;

        public static frmEvolucion fEvolucion
        {
            
            get 
            {
                if (_fEvolucion == null || _fEvolucion.IsDisposed)
                    _fEvolucion = new frmEvolucion();
                return _fEvolucion; 
            }
            set { _fEvolucion = value; }
        }
        
    }
}
