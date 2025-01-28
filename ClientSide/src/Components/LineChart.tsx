import React from "react";
import { Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

interface Price {
  value: number;
  productId: number;
  date: string;
}

interface LineChartProps {
  priceHistory: Price[];
}

const LineChart: React.FC<LineChartProps> = ({ priceHistory }) => {
  const values = priceHistory.map((price) => price.value);
  const dates = priceHistory.map((price) => price.date.slice(0, 10).trim());

  const chartData = {
    labels: dates,
    datasets: [
      {
        label: "Price History",
        data: values,
        borderColor: "#3b82f6",
        backgroundColor: "rgba(59, 130, 246, 0.5)",
        tension: 0.4,
      },
    ],
  };

  const options = {
    responsive: true,
    maintainAspectRatio: false, 
    plugins: {
      legend: {
        display: true,
        position: "top" as const,
      },
    },
    scales: {
      x: {
        title: {
          display: true,
          text: "Date",
        },
      },
      y: {
        title: {
          display: true,
          text: "Price",
        },
      },
    },
  };

  return (
    <div className="w-full h-96 md:h-[400px] md:w-[700px] bg-white p-4 rounded-lg shadow-md dark:bg-gray-800 mx-auto">
      <Line data={chartData} options={options} />
    </div>
  );
};

export default LineChart;
