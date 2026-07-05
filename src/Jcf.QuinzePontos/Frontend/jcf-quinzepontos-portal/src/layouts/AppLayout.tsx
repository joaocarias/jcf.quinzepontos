import { Outlet } from 'react-router-dom'
import { Topbar } from '../components/Topbar'
import { Sidebar } from '../components/Sidebar'

export function AppLayout() {
  return (
    <div className="min-h-screen bg-canvas font-body text-ink">
      <Topbar />
      <div className="flex">
        <Sidebar />
        <main className="flex-1 p-8">
          <Outlet />
        </main>
      </div>
    </div>
  )
}
