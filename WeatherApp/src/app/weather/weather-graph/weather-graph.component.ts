import {Component, inject, Input, OnChanges, SimpleChanges} from '@angular/core';
import {WeatherDataService} from "../../services/weather-data.service";
import {Chart} from "chart.js";
import {TemperatureProviderService} from "../../services/temperature-provider.service";
import {GraphDataService} from "../../services/graph-data.service";

@Component({
  selector: 'app-weather-graph',
  standalone: true,
  imports: [],
  templateUrl: './weather-graph.component.html',
  styleUrl: './weather-graph.component.css'
})
export class WeatherGraphComponent implements OnChanges {
  @Input() country!: string;
  @Input() city!: string;
  @Input() from!: string;
  @Input() to!: string;

  private graphDataSrv = inject(GraphDataService);

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['country'] || changes['city'] || changes['from'] || changes['to']) {
      this.loadDataAndRenderChart();
    }
  }

  loadDataAndRenderChart() {
    /*if (this.city) {
      this.graphDataSrv.getTemperatureByCity(this.city, this.from, this.to).subscribe(data => {
        this.renderChart(data);
      });
    } else if (this.country) {
      this.graphDataSrv.getAverageTemperatureByCountry(this.country, this.from, this.to).subscribe(data => {
        this.renderChart(data);
      });
    }*/
  }

  renderChart(data: any) {
    const ctx = (document.getElementById('temperatureChart') as HTMLCanvasElement).getContext('2d');

    new Chart(ctx!, {
      type: 'line',
      data: {
        labels: data.dates, // x-axis labels
        datasets: [{
          label: 'Temperature',
          data: data.temperatures,
          borderColor: 'rgba(75, 192, 192, 1)',
          borderWidth: 1,
          fill: false
        }]
      },
      options: {
        scales: {
          x: {
            type: 'time',
            time: {
              unit: 'day'
            }
          },
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }

}
