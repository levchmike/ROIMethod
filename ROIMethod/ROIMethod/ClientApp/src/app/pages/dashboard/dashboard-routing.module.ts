import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { AuthService } from 'src/app/services/firebase.auth.service'
import { AuthGuard } from 'src/app/components/cleanui/layout/Guard/auth.guard'
import { LayoutsModule } from 'src/app/layouts/layouts.module'

// dashboard
import { DashboardAlphaComponent } from 'src/app/pages/dashboard/alpha/alpha.component'


const routes: Routes = [
  {
    path: 'alpha',
    component: DashboardAlphaComponent,
    data: { title: 'Dashboard Alpha' },
  }
]

@NgModule({
  imports: [LayoutsModule, RouterModule.forChild(routes)],
  providers: [AuthService],
  exports: [RouterModule],
})
export class DashboardRouterModule {}
