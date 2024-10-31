﻿using MyDoctorAppointment.Data.Interfaces;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Service.Services
{
    public class XmlDataSerializerService : ISerializationService
    {
        public T Deserialize<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public void Serialize<T>(string path, T data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }
    }
}