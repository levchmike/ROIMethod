import { Component, Input, OnInit } from '@angular/core'
import { Observable } from 'rxjs'
import { AuthService } from 'src/app/services/firebase.auth.service'

@Component({
  selector: 'cui-acl',
  template: `
    <ng-content *ngIf="authorized"></ng-content>
  `,
})
export class ACLComponent implements OnInit {
  @Input() roles: any[] = []
  authorized: Boolean = false
  role: string = ''

  constructor(public authService: AuthService) {}

  ngOnInit() {
    const user = JSON.parse(localStorage.getItem('user'))
    this.authorized = this.roles.includes(user.role)
  }
}
