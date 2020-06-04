import { Injectable } from '@angular/core'
import { AngularFireAuth } from '@angular/fire/auth'
import { AngularFirestore } from '@angular/fire/firestore'
import { Router } from '@angular/router'
import { NzNotificationService } from 'ng-zorro-antd'

interface User {
  uid: string
  email: string
  displayName: string
  photoURL: string
  emailVerified: boolean
  role: string
}

export const firebaseConfig = {
  apiKey: 'AIzaSyAE5G0RI2LwzwTBizhJbnRKIKbiXQIA1dY',
  authDomain: 'cleanui-72a42.firebaseapp.com',
  databaseURL: 'https://cleanui-72a42.firebaseio.com',
  projectId: 'cleanui-72a42',
  storageBucket: 'cleanui-72a42.appspot.com',
  messagingSenderId: '583382839121',
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    public afs: AngularFirestore,
    public afAuth: AngularFireAuth,
    public router: Router,
    private notification: NzNotificationService,
  ) {
    this.afAuth.authState.subscribe(user => {
      if (user) {
        const _user = JSON.parse(JSON.stringify(user))
        // TODO: modify this code for your needs
        localStorage.setItem(
          'user',
          JSON.stringify({
            id: _user.uid,
            name: 'Administrator',
            email: _user.email,
            role: 'admin',
            avatar: '',
            authorized: true, // set app to authorized state
            loading: false,
          }),
        )
      } else {
        localStorage.setItem('user', null)
      }
    })
  }

  async SignIn(email: string, password: string) {
    try {
      await this.afAuth.signInWithEmailAndPassword(email, password)
      this.router.navigate(['dashboard/alpha'])
      this.notification.success(
        'Logged In',
        'You have successfully logged in to Clean UI Angular Admin Template!',
      )
    } catch (error) {
      this.notification.error(error.code, error.message)
    }
  }

  get getUser() {
    return this.afAuth.user
  }

  async SignOut() {
    await this.afAuth.signOut()
    localStorage.removeItem('user')
    this.router.navigate(['auth/login'])
  }
}
