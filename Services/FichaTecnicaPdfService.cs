//using QuestPDF.Fluent;
//using QuestPDF.Helpers;
//using QuestPDF.Infrastructure;
//using AxClock.Models;
//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace AxClock.Services
//{
//    public class FichaTecnicaPdfService
//    {
//        public byte[] GerarFichaTecnicaPdf(
//            string nomeArtigo,
//            List<CardFase> listaFasesCard,
//            List<CrmFaseMateriais> listaComponentes,
//            decimal totalCustoAllPhases,
//            decimal totalCustoArtigosAllPhases,
//            decimal totalCustoServicosAllPhases,
//            decimal totalPesoAllPhases)
//        {
//            // Configurando o documento
//            var documento = Document.Create(document =>
//            {
//                document.Page(page =>
//                {
//                    page.Size(PageSizes.A4.Landscape());
//                    page.Margin(20);

//                    // Cabeçalho
//                    page.Header().Element(container =>
//                    {
//                        container.Row(row =>
//                        {
//                            row.RelativeItem().Column(col =>
//                            {
//                                col.Item().AlignCenter().Text("Ficha Técnica")
//                                    .FontSize(20)
//                                    .Bold()
//                                    .FontColor(Colors.Blue.Medium);

//                                col.Item().Text($"Data: {DateTime.Now:dd/MM/yyyy}")
//                                    .FontSize(10);
//                            });
//                        });
//                    });

//                    // Conteúdo
//                    page.Content().Element(contentContainer =>
//                    {
//                        contentContainer.Column(mainCol =>
//                        {
//                            // Informações do artigo
//                            mainCol.Item().PaddingVertical(10).Column(infoCol =>
//                            {
//                                infoCol.Item().Text($"Artigo: {nomeArtigo}")
//                                    .FontSize(12)
//                                    .Bold();
//                            });

//                            // Fases
//                            foreach (var fase in listaFasesCard)
//                            {
//                                var componentesDaFase = listaComponentes
//                                    .Where(c => c.FaseId == fase.Id)
//                                    .ToList();

//                                var artigosDaFase = componentesDaFase
//                                    .Where(c => c.IsServico == false)
//                                    .OrderBy(c => c.Ordem)
//                                    .ToList();

//                                var servicosDaFase = componentesDaFase
//                                    .Where(c => c.IsServico == true)
//                                    .OrderBy(c => c.Ordem)
//                                    .ToList();

//                                mainCol.Item().PaddingVertical(5).Border(1).BorderColor(Colors.Teal.Medium).Padding(10).Column(faseCol =>
//                                {
//                                    // Cabeçalho da fase
//                                    faseCol.Item().Background(Colors.Teal.Medium).Padding(5).Row(faseHeader =>
//                                    {
//                                        faseHeader.RelativeItem().AlignLeft().Text($"FASE {fase.Ordem + 1}: {fase.DescricaoFase ?? "Sem descrição"}")
//                                            .FontSize(12)
//                                            .Bold()
//                                            .FontColor(Colors.White);
//                                    });

//                                    // Segunda linha de informações
//                                    faseCol.Item().Background(Colors.Grey.Lighten2).Padding(5).Row(faseInfo =>
//                                    {
//                                        faseInfo.RelativeItem().AlignLeft().Text($"PESO: {fase.PesoArtigosFase:F3} g")
//                                          .FontSize(12)
//                                          .Bold()
//                                          .FontColor(Colors.Black);

//                                        faseInfo.RelativeItem().AlignLeft().Text($"ARTIGOS: {fase.CustoArtigosFase:F2} €")
//                                            .FontSize(12)
//                                            .Bold()
//                                            .FontColor(Colors.Black);

//                                        faseInfo.RelativeItem().AlignLeft().Text($"SERVIÇOS: {fase.CustoServicosFase:F2} €")
//                                            .FontSize(12)
//                                            .Bold()
//                                            .FontColor(Colors.Black);

//                                        faseInfo.RelativeItem().AlignLeft().Text($"CUSTO: {fase.Custo:F2} €")
//                                            .FontSize(12)
//                                            .Bold()
//                                            .FontColor(Colors.Black);
//                                    });

//                                    // Serviços
//                                    if (servicosDaFase.Count > 0)
//                                    {
//                                        faseCol.Item().PaddingTop(10).Element(servicosHeader =>
//                                        {
//                                            servicosHeader.Row(row =>
//                                            {
//                                                row.RelativeItem().Text("Serviços")
//                                                    .FontSize(12)
//                                                    .Bold()
//                                                    .FontColor(Colors.Blue.Medium);
//                                            });
//                                        });

//                                        faseCol.Item().BorderBottom(2).BorderColor(Colors.Teal.Medium);

//                                        // Tabela de serviços
//                                        faseCol.Item().Table(table =>
//                                        {
//                                            // Definição de colunas
//                                            table.ColumnsDefinition(columns =>
//                                            {
//                                                columns.ConstantColumn(120);    // Tipo
//                                                columns.RelativeColumn(3);      // Descrição
//                                                columns.ConstantColumn(60);     // Quantidade
//                                                columns.ConstantColumn(60);     // Unidade
//                                                columns.ConstantColumn(100);    // Custo
//                                            });

//                                            // Cabeçalho da tabela
//                                            table.Header(header =>
//                                            {
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("TIPO").FontSize(10).Bold();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("DESCRIÇÃO").FontSize(10).Bold();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("QNT").FontSize(10).Bold().AlignCenter();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("UND").FontSize(10).Bold().AlignCenter();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("CUSTO").FontSize(10).Bold().AlignRight();
//                                            });

//                                            // Linhas de dados e observações integradas
//                                            foreach (var servico in servicosDaFase)
//                                            {
//                                                // Linha principal do serviço
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text(servico.TipoServico ?? "").FontSize(10);
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(servico.ComponenteDescricao ?? "").FontSize(10);
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text($"{servico.Quantidade}").FontSize(10).AlignCenter();
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(servico.Unidade ?? "").FontSize(10).AlignCenter();
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text($"{servico.Custo:F2} €").FontSize(10).AlignRight();

//                                                // Se tiver observações, adiciona uma linha de observações abaixo
//                                                if (!string.IsNullOrEmpty(servico.Obs))
//                                                {
//                                                    table.Cell().ColumnSpan(5).PaddingTop(8);
//                                                    table.Cell().ColumnSpan(5).BorderBottom(1).Padding(4).Element(obsElement =>
//                                                    {
//                                                        obsElement.Text(text =>
//                                                        {
//                                                            text.Span("OBSERVAÇÕES: ").FontSize(10).Bold();
//                                                            text.Span(servico.Obs).FontSize(10);
//                                                        });
//                                                    });
//                                                    table.Cell().ColumnSpan(5).PaddingBottom(8);
//                                                }
//                                            }
//                                        });
//                                    }

//                                    // Artigos
//                                    if (artigosDaFase.Count > 0)
//                                    {
//                                        faseCol.Item().PaddingTop(10).Element(artigosHeader =>
//                                        {
//                                            artigosHeader.Row(row =>
//                                            {
//                                                row.RelativeItem().Text("Artigos")
//                                                    .FontSize(12)
//                                                    .Bold()
//                                                    .FontColor(Colors.Blue.Medium);
//                                            });
//                                        });

//                                        faseCol.Item().BorderBottom(2).BorderColor(Colors.Teal.Medium);

//                                        // Tabela de artigos
//                                        faseCol.Item().Table(table =>
//                                        {
//                                            // Definição de colunas - Removida a coluna Família
//                                            table.ColumnsDefinition(columns =>
//                                            {
//                                                columns.ConstantColumn(120);    // Tipo
//                                                columns.RelativeColumn(4);      // Descrição - aumentada para compensar a remoção da coluna Família
//                                                columns.ConstantColumn(60);     // Quantidade
//                                                columns.ConstantColumn(60);     // Unidade
//                                                columns.ConstantColumn(100);    // Custo
//                                            });

//                                            // Cabeçalho da tabela
//                                            table.Header(header =>
//                                            {
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("TIPO").FontSize(10).Bold();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("DESCRIÇÃO").FontSize(10).Bold();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("QNT").FontSize(10).Bold().AlignCenter();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("UND").FontSize(10).Bold().AlignCenter();
//                                                header.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text("CUSTO").FontSize(10).Bold().AlignRight();
//                                            });

//                                            // Linhas de dados com observações e detalhes de corte integrados
//                                            foreach (var artigo in artigosDaFase)
//                                            {
//                                                // Linha principal do artigo
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text(artigo.TipoServico ?? "").FontSize(10);
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(artigo.ComponenteDescricao ?? "").FontSize(10);
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text($"{artigo.Quantidade}").FontSize(10).AlignCenter();
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text(artigo.Unidade ?? "").FontSize(10).AlignCenter();
//                                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Text($"{artigo.Custo:F2} €").FontSize(10).AlignRight();

//                                                // Se tiver observações, adiciona uma linha de observações
//                                                if (!string.IsNullOrEmpty(artigo.Obs))
//                                                {
//                                                    table.Cell().ColumnSpan(5).PaddingTop(8);
//                                                    table.Cell().ColumnSpan(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(2).Element(obsElement =>
//                                                    {
//                                                        obsElement.Text(text =>
//                                                        {
//                                                            text.Span("OBSERVAÇÕES: ").FontSize(10).Bold();
//                                                            text.Span(artigo.Obs).FontSize(10);
//                                                        });
//                                                    });
//                                                }

//                                                // Se tiver cálculo de corte, adiciona uma linha com detalhes do corte
//                                                if (artigo.CalculaCorte == true)
//                                                {
//                                                    table.Cell().ColumnSpan(5).PaddingTop(8);
//                                                    table.Cell().ColumnSpan(5).BorderBottom(1).Padding(2).Element(corteElement =>
//                                                    {
//                                                        corteElement.Column(corteCol =>
//                                                        {
//                                                            corteCol.Item().PaddingBottom(4).Text("CÁLCULO CORTE:").FontSize(10).Bold();

//                                                            // Detalhes do cálculo de corte (mais compacto)
//                                                            corteCol.Item().Row(row =>
//                                                            {
//                                                                row.RelativeItem(1).Padding(4).Text($"PESO BASE: {artigo.Peso:F3} {artigo.PesoUnit}").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"CORTE MESA: {artigo.Altura:F2}").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"CORTE ROLO: {artigo.Largura:F2}").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"QNT PEÇAS: {artigo.QntPecas}").FontSize(9);
//                                                            });

//                                                            // Cálculos adicionais baseados em fórmulas
//                                                            corteCol.Item().BorderTop(0.5f).BorderColor(Colors.Grey.Lighten2).PaddingTop(2).PaddingBottom(2).Row(row =>
//                                                            {
//                                                                // Primeira linha de cálculos
//                                                                row.RelativeItem(1).Padding(4).Text($"PESO PEÇA: {CalcularPesoTotal(artigo):F3} g").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"CONS. M2 LINEAR: {CalcularMPorPeca(artigo):F3} m²").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"QNT TOTAL M2: {CalcularMTotal(artigo):F3} m²").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"QNT UNIT. M2: {Math.Abs(CalcularQntUnitariaM2(artigo)):F3} m²").FontSize(9);
//                                                            });

//                                                            // Balanço de massa
//                                                            corteCol.Item().BorderTop(0.5f).BorderColor(Colors.Grey.Lighten2).PaddingTop(4).PaddingBottom(4).Text("BALANÇO MASSA:").FontSize(10).Bold();

//                                                            corteCol.Item().Row(row =>
//                                                            {
//                                                                row.RelativeItem(1).Padding(4).Text($"CONS. TOTAL KG: {ConsumoTotalKG(artigo):F3} Kg").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"DESP. TOTAL KG: {DesperdicioTotalKG(artigo):F3} Kg").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Text($"DESP. UNIT. KG: {DesperdicioUnitarioKG(artigo):F3} Kg").FontSize(9);
//                                                                row.RelativeItem(1).Padding(4).Element(emptySpace => { });
//                                                            });
//                                                        });
//                                                    });
//                                                    table.Cell().ColumnSpan(5).PaddingBottom(8);
//                                                }
//                                            }
//                                        });
//                                    }
//                                });
//                            }

//                            // Resumo total
//                            mainCol.Item().PaddingVertical(5).Border(1).BorderColor(Colors.Teal.Medium).Padding(10).Column(totaisCol =>
//                            {
//                                // Cabeçalho da fase
//                                totaisCol.Item().Background(Colors.Teal.Medium).Padding(5).Row(faseHeaderEnd =>
//                                {
//                                    faseHeaderEnd.RelativeItem().AlignLeft().Text("Total Geral:")
//                                      .FontSize(14)
//                                      .Bold().FontColor(Colors.White);
//                                });

//                                totaisCol.Item().Background(Colors.Grey.Lighten3).Padding(5).Row(row =>
//                                {
//                                    row.RelativeItem().AlignLeft().Text($"Total Peso: {totalPesoAllPhases:F3} g")
//                                        .FontSize(12).Bold();

//                                    row.RelativeItem().AlignLeft().Text($"Total Artigos: {totalCustoArtigosAllPhases:F2} €")
//                                        .FontSize(12).Bold();

//                                    row.RelativeItem().AlignLeft().Text($"Total Serviços: {totalCustoServicosAllPhases:F2} €")
//                                        .FontSize(12).Bold();

//                                    row.RelativeItem().AlignLeft().Text($"Total Custo: {totalCustoAllPhases:F2} €")
//                                      .FontSize(12)
//                                      .Bold();

//                                });
//                            });
//                        });
//                    });

//                    // Rodapé
//                    page.Footer().AlignCenter().Text(text =>
//                    {
//                        text.Span("Página ").FontSize(10);
//                        text.CurrentPageNumber().FontSize(10);
//                        text.Span(" de ").FontSize(10);
//                        text.TotalPages().FontSize(10);
//                    });
//                });
//            });

//            // Gera o PDF em formato byte[]
//            return documento.GeneratePdf();
//        }

//        #region Métodos de Cálculo
//        // Cálculo de peso total
//        private decimal CalcularPesoTotal(CrmFaseMateriais componente)
//        {
//            decimal largura = componente.Largura ?? decimal.Zero;
//            decimal altura = componente.Altura ?? decimal.Zero;
//            decimal pesoBase = componente.Peso ?? decimal.Zero;

//            return (largura * altura * pesoBase);
//        }

//        // Cálculo de m² por peça
//        private decimal CalcularMPorPeca(CrmFaseMateriais componente)
//        {
//            decimal altura = componente.Altura ?? 0;
//            int qntPecas = componente.QntPecas ?? 1;

//            if (qntPecas <= 0)
//                qntPecas = 1;

//            return (altura) / qntPecas;
//        }

//        // Cálculo de m² total
//        private decimal CalcularMTotal(CrmFaseMateriais componente)
//        {
//            decimal larguraArtigo = componente.LarguraArtigo ?? 1;
//            decimal altura = componente.Altura ?? 0;
//            return (larguraArtigo * altura) / 100;
//        }

//        // Cálculo de quantidade unitária em m²
//        private decimal CalcularQntUnitariaM2(CrmFaseMateriais componente)
//        {
//            decimal altura = componente.Altura ?? decimal.Zero;
//            decimal largura = componente.Largura ?? decimal.Zero;
//            return altura * largura;
//        }

//        // Cálculo de consumo total em kg
//        private decimal ConsumoTotalKG(CrmFaseMateriais componente)
//        {
//            decimal quantidadeTotalM2 = CalcularMTotal(componente);
//            decimal? pesoBase = componente.Peso;

//            if (pesoBase.HasValue)
//            {
//                return quantidadeTotalM2 * pesoBase.Value;
//            }
//            return decimal.Zero;
//        }

//        // Cálculo de desperdício total em kg
//        private decimal DesperdicioTotalKG(CrmFaseMateriais componente)
//        {
//            decimal consumoTotalKg = ConsumoTotalKG(componente);
//            decimal pesoPeca = CalcularPesoTotal(componente);
//            int? qntPecas = componente.QntPecas;

//            if (qntPecas.HasValue && qntPecas.Value > 0)
//            {
//                return consumoTotalKg - (pesoPeca * qntPecas.Value);
//            }
//            return consumoTotalKg;
//        }

//        // Cálculo de desperdício unitário em kg
//        private decimal DesperdicioUnitarioKG(CrmFaseMateriais componente)
//        {
//            decimal desperdicioTotalKg = DesperdicioTotalKG(componente);
//            int? qntPecas = componente.QntPecas;

//            if (qntPecas.HasValue && qntPecas.Value > 0)
//            {
//                return desperdicioTotalKg / qntPecas.Value;
//            }
//            return decimal.Zero;
//        }
//        #endregion
//    }
//}