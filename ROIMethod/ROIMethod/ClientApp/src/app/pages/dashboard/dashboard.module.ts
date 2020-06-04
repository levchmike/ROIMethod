import { NgModule } from '@angular/core'
import { SharedModule } from 'src/app/shared.module'
import { DashboardRouterModule } from './dashboard-routing.module'
import { WidgetsComponentsModule } from 'src/app/components/kit/widgets/widgets-components.module'
import { FormsModule } from '@angular/forms'
import { ChartistModule } from 'ng-chartist'
import { NgApexchartsModule } from 'ng-apexcharts'

// dashboard
import { DashboardAlphaComponent } from 'src/app/pages/dashboard/alpha/alpha.component'


const COMPONENTS = [
  DashboardAlphaComponent
]

@NgModule({
  imports: [
    SharedModule,
    DashboardRouterModule,
    WidgetsComponentsModule,
    FormsModule,
    ChartistModule,
    NgApexchartsModule,
  ],
  declarations: [...COMPONENTS],
})
export class DashboardModule {}
