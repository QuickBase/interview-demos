require 'serverspec'

if RUBY_PLATFORM == 'i386-mingw32'
  set :backend, :cmd
  set :os, family: 'windows'

else
  set :backend, :exec
end
