using Progreso2ML.Models;
using Progreso2ML.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Progreso2ML.ViewModel;

public class ViewModelML : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ViewModelML()
    {
        dateTime = DateTime.Now;
        title = string.Empty;
        latitude = string.Empty;
        longitude = string.Empty;
        service = new ServiceML();
    }

    private DateTime dateTime;
    public DateTime ChosenDate
    {
        get { return dateTime; }
        set
        {
            if (value != dateTime)
            {
                dateTime = value;
                NotifyPropertyChanged();
            }
            _ = GetInfo();
        }
    }

    private string title;
    public string Title
    {
        get { return title; }
        set
        {
            if (value != title)
            {
                title = value;
                NotifyPropertyChanged();
            }
        }
    }

    private string latitude;
    public string Latitude
    {
        get { return latitude; }
        set
        {
            if (latitude != value)
            {
                latitude = value;
                NotifyPropertyChanged();
            }
        }
    }

    private string longitude;
    public string Longitude
    {
        get { return longitude; }
        set
        {
            if (longitude != value)
            {
                longitude = value;
                NotifyPropertyChanged();
            }
        }
    }

    private ServiceML service;
    public ServiceML Service
    {
        get
        {
            if (service == null)
            {
                service = new ServiceML();
            }
            return service;
        }
    }

    private async Task GetInfo()
    {
        ModelML dto = await Service.GetWeather();
        if (dto == null)
        {
            Title = "error";
        }
        else
        {
            Latitude = dto.latitude;
            Longitude = dto.longitude;
        }
    }
}
