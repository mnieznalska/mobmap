﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace MOBMAP.Hardware
{
    class PostWm5GpsHandler : Hardware.IGps
    {
        private IntPtr gpsHandle = IntPtr.Zero;

        public IntPtr getGpsHandle()
        {
            return gpsHandle;
        }

        private bool gpsPresent()
        {
            RegistryKey rk = Registry.LocalMachine;

            try
            {
                RegistryKey rkGpsId = rk.OpenSubKey(@"\System\CurrentControlSet\GPS Intermediate Driver\Multiplexer");

                try
                {
                    //IF subKey EXIST AND HAVE VALUE "DriverInterface" THEN DEVICE have build in GPS
                    if (rkGpsId.GetValue("DriverInterface") == null)
                    {
                        //"Don't have build in GPS"
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("gps pres" + ex.Message);
                    
                    return false;
                }
                finally
                {
                    rkGpsId.Close();
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
            finally
            {
                rk.Close();
            }
            //"have build in gps"
            return true;
        }

        //CONNECT EXTERNAL gps (np bt)
        private bool fakeGpsPresent()
        {
            RegistryKey rk = Registry.LocalMachine;

            try
            {
                RegistryKey rkGpsId = rk.OpenSubKey(@"\System\CurrentControlSet\GPS Intermediate Driver\Drivers");

                try
                {
                    if (rkGpsId.GetSubKeyNames().Length != 0)
                    {
                        //"have external gps"
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("fake gps"+ex.Message);
                   
                    return false;
                }
                finally
                {
                    rkGpsId.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("post wm"+ex.Message);
                
                return false;
            }
            finally
            {
                rk.Close();
            }
            //"don't have external gps"
            return false; 
        }

        #region IGps Members
        public bool hasGPS
        {
            get
            {
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rkGpsId;
                try
                {                    
                    if ((rkGpsId = rk.OpenSubKey(@"System\CurrentControlSet\GPS Intermediate Driver\Drivers")) != null)
                    {
                        try
                        {
                            if (rkGpsId.GetValue("CurrentDriver") == null)
                            {// No GPS receiver registered.
                              
                                return false;
                            }
                            else
                            {// A GPS receiver is available.
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("post w"+ex.Message);
                            
                            return false;
                        }
                        finally
                        {
                            rkGpsId.Close();
                        }
                    }
                    else //no registry key
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    
                    return false;
                }
                finally
                {
                    rk.Close();
                }
            }
        }
        #endregion
    }
}
