using System;
using System.Collections;
using System.Collections.Generic;
using static TpLinkSharp.Utilities.StringUtilities;

namespace TpLinkSharp.Models.SystemTools
{
    public class BandwidthStatisticsCollection : IEnumerable<BandwidthStatistics>
    {
        private const int RowsParameterIndex = 4;
        private const int RowLengthParameterIndex = 5;
        private const int StatisticsArraysIndex = 0;
        private const int ParametersArrayIndex = 1;

        private readonly string[][] _parsedArrays;

        private int Rows { get; }
        private int RowLength { get; }

        private BandwidthStatisticsCollection(string[][] parsedArrays)
        {
            _parsedArrays = parsedArrays;

            Rows = int.Parse(_parsedArrays[ParametersArrayIndex][RowsParameterIndex]);
            RowLength = int.Parse(_parsedArrays[ParametersArrayIndex][RowLengthParameterIndex]);
        }

        public IEnumerator<BandwidthStatistics> GetEnumerator() => GenerateBandwidthStatistics().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GenerateBandwidthStatistics().GetEnumerator();

        public static BandwidthStatisticsCollection FromHtmlResponse(string responseHtml)
        {
            var parsedArrays = ExtractJavascriptArrays(responseHtml);

            return new BandwidthStatisticsCollection(parsedArrays);
        }

        private IEnumerable<BandwidthStatistics> GenerateBandwidthStatistics()
        {
            var rawStatisticsArray = _parsedArrays[StatisticsArraysIndex];

            for (var i = 0; i < Rows; i++)
            {
                var rowStart = i * RowLength;
                var rowEnd = rowStart + RowLength;

                yield return new BandwidthStatistics(new ArraySegment<string>(rawStatisticsArray, rowStart, rowEnd));
            }
        }
    }
}