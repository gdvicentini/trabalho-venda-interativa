using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Venda.Iterativa.Classes;
using Venda.Iterativa.ViewModel;

namespace Venda.Iterativa.Commands
{
    internal sealed class FinalizarPedidoCarrinhoCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var rvm = parameter as ReceberViewModel;
            var dadosCartao = rvm.Pedido;

            if(dadosCartao.NumCartao.Length != 16)
            {
                MessageBox.Show("Quantidade de dígitos inválido. Informe os 16 números corretamente!");
                return;
            }

            if(dadosCartao.Validade < DateTime.Today)
            {
                MessageBox.Show("A data de validade informada é inválida. Não pode ter data de validade menor que o dia atual!");
                return;
            }

            if(dadosCartao.CVV.ToString().Length != 3)
            {
                MessageBox.Show("Número de dígitos inválido. Informe o CVV corretamente");
                return;
            }

            MessageBox.Show("Dados preenchidos corretamente. Pedido foi finalizado com sucesso!");
        }
    }
}
