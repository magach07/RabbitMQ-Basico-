﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.InteropServices;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

internal class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        using(var connection = factory.CreateConnection())
        {
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare
                (
                    queue: "saudacao_1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                string message = "Bem vindo ao RabbitMQ";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish
                (
                    exchange:"",
                    routingKey: "saudacao_1",
                    basicProperties: null,
                    body: body
                );

                Console.WriteLine($"[x] Enviada: {message}");
            }
        }
    }
}